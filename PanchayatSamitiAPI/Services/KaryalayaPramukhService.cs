using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class KaryalayaPramukhService : IKaryalayaPramukhService
    {
        private readonly IRepository<KaryalayaPramukh> _repository;

        public KaryalayaPramukhService(IRepository<KaryalayaPramukh> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddKaryalayaPramukhAsync(KaryalayaPramukhModel model)
        {
            var entity = new KaryalayaPramukh
            {
                UniqueId = Guid.NewGuid(),
                KaryalayaPramukh1 = model.KaryalayaPramukh ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<KaryalayaPramukhModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<KaryalayaPramukhModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new KaryalayaPramukhModel
                {
                    Id = item.Id,
                    KaryalayaPramukh = item.KaryalayaPramukh1,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<KaryalayaPramukhModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new KaryalayaPramukhModel
            {
                Id = entity.Id,
                KaryalayaPramukh = entity.KaryalayaPramukh1,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(KaryalayaPramukhModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("KaryalayaPramukh not found");

            var updated = new KaryalayaPramukh
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
                KaryalayaPramukh1 = model.KaryalayaPramukh ?? existing.KaryalayaPramukh1,
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
