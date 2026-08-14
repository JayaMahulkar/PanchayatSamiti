using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class RetirementOfficeService : IRetirementOfficeService
    {
        private readonly IRepository<RetirementOfficeMaster> _repository;

        public RetirementOfficeService(IRepository<RetirementOfficeMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddRetirementOfficeAsync(RetirementOfficeModel model)
        {
            var entity = new RetirementOfficeMaster
            {
                UniqueId = Guid.NewGuid(),
                RetirementOffice = model.RetirementOffice ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<RetirementOfficeModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<RetirementOfficeModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new RetirementOfficeModel
                {
                    Id = item.Id,
                    RetirementOffice = item.RetirementOffice,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<RetirementOfficeModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new RetirementOfficeModel
            {
                Id = entity.Id,
                RetirementOffice = entity.RetirementOffice,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(RetirementOfficeModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("RetirementOffice not found");

            var updated = new RetirementOfficeMaster
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
                RetirementOffice = model.RetirementOffice ?? existing.RetirementOffice,
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
