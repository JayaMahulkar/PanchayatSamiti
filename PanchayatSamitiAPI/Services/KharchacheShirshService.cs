using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class KharchacheShirshService : IKharchacheShirshService
    {
        private readonly IRepository<KharchacheShirshMaster> _repository;

        public KharchacheShirshService(IRepository<KharchacheShirshMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddKharchacheShirshAsync(KharchacheShirshModel model)
        {
            var entity = new KharchacheShirshMaster
            {
                UniqueId = Guid.NewGuid(),
                KharchacheShirsh = model.KharchacheShirsh ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<KharchacheShirshModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<KharchacheShirshModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new KharchacheShirshModel
                {
                    Id = item.Id,
                    KharchacheShirsh = item.KharchacheShirsh,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<KharchacheShirshModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new KharchacheShirshModel
            {
                Id = entity.Id,
                KharchacheShirsh = entity.KharchacheShirsh,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(KharchacheShirshModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("KharchacheShirsh not found");

            var updated = new KharchacheShirshMaster
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
                KharchacheShirsh = model.KharchacheShirsh ?? existing.KharchacheShirsh,
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
