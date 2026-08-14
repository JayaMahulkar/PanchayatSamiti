// This file intentionally duplicates namespace used by other services to match project layout
using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class RelationService : IRelationService
    {
        private readonly IRepository<RelationMaster> _repository;

        public RelationService(IRepository<RelationMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddRelationAsync(RelationModel model)
        {
            var entity = new RelationMaster
            {
                UniqueId = Guid.NewGuid(),
                Relation = model.Relation ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<RelationModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<RelationModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new RelationModel
                {
                    Id = item.Id,
                    Relation = item.Relation,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<RelationModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new RelationModel
            {
                Id = entity.Id,
                Relation = entity.Relation,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(RelationModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("Relation not found");

            var updated = new RelationMaster
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
                Relation = model.Relation ?? existing.Relation,
                IsActive = model.IsActive ?? existing.IsActive,
                CreatedBy = existing.CreatedBy,
                CreatedDate = existing.CreatedDate,
                UpdatedBy = "System",
                UpdatedDate = DateTime.Now,
                IsDeleted = existing.IsDeleted
            };

            await _repository.UpdateAsync(updated);
        }
    }
}
