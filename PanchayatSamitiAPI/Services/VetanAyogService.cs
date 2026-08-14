using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class VetanAyogService : IVetanAyogService
    {
        private readonly IRepository<VetanAyogMaster> _repository;

        public VetanAyogService(IRepository<VetanAyogMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddVetanAyogAsync(VetanAyogModel model)
        {
            var entity = new VetanAyogMaster
            {
                UniqueId = Guid.NewGuid(),
                VetanAyog = model.VetanAyog ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<VetanAyogModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<VetanAyogModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new VetanAyogModel
                {
                    Id = item.Id,
                    VetanAyog = item.VetanAyog,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<VetanAyogModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new VetanAyogModel
            {
                Id = entity.Id,
                VetanAyog = entity.VetanAyog,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(VetanAyogModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("VetanAyog not found");

            var updated = new VetanAyogMaster
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
                VetanAyog = model.VetanAyog ?? existing.VetanAyog,
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
