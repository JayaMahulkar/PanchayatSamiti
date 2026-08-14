using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class KhatePramukhService : IKhatePramukhService
    {
        private readonly IRepository<KhatePramukhMaster> _repository;

        public KhatePramukhService(IRepository<KhatePramukhMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddKhatePramukhAsync(KhatePramukhModel model)
        {
            var entity = new KhatePramukhMaster
            {
                UniqueId = Guid.NewGuid(),
                KhatePramukh = model.KhatePramukh ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<KhatePramukhModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<KhatePramukhModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new KhatePramukhModel
                {
                    Id = item.Id,
                    KhatePramukh = item.KhatePramukh,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<KhatePramukhModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new KhatePramukhModel
            {
                Id = entity.Id,
                KhatePramukh = entity.KhatePramukh,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(KhatePramukhModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("KhatePramukh not found");

            var updated = new KhatePramukhMaster
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
                KhatePramukh = model.KhatePramukh ?? existing.KhatePramukh,
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
