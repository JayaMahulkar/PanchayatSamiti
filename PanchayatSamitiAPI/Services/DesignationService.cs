using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly IRepository<DesignationMaster> _repository;

        public DesignationService(IRepository<DesignationMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddDesignationAsync(DesignationModel model)
        {
            var entity = new DesignationMaster
            {
                Designation = model.Designation ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedBy = 1,
                UpdatedBy = 1,
                UniqueId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedBy = DateTime.Now
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<DesignationModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<DesignationModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new DesignationModel
                {
                    Id = item.Id,
                    Designation = item.Designation,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<DesignationModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new DesignationModel
            {
                Id = entity.Id,
                Designation = entity.Designation,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(DesignationModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("Designation not found");

            var updated = new DesignationMaster
            {
                Id = model.Id,
                Designation = model.Designation ?? existing.Designation,
                IsActive = model.IsActive ?? existing.IsActive,
                CreatedBy = existing.CreatedBy,
                UpdatedBy = existing.UpdatedBy,
                UniqueId = existing.UniqueId,
                CreatedDate = existing.CreatedDate,
                ModifiedBy = DateTime.Now
            };

            await _repository.UpdateAsync(updated);
        }
    }
}
