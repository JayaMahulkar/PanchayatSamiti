using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class BankecheTapshilService : IBankecheTapshilService
    {
        private readonly IRepository<BankecheTapshilMaster> _repository;

        public BankecheTapshilService(IRepository<BankecheTapshilMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddBankecheTapshilAsync(BankecheTapshilModel model)
        {
            var entity = new BankecheTapshilMaster
            {
                UniqueId = Guid.NewGuid(),
                BankecheTapshil = model.BankecheTapshil ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<BankecheTapshilModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<BankecheTapshilModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new BankecheTapshilModel
                {
                    Id = item.Id,
                    BankecheTapshil = item.BankecheTapshil,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<BankecheTapshilModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new BankecheTapshilModel
            {
                Id = entity.Id,
                BankecheTapshil = entity.BankecheTapshil,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(BankecheTapshilModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("BankecheTapshil not found");

            var updated = new BankecheTapshilMaster
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
                BankecheTapshil = model.BankecheTapshil ?? existing.BankecheTapshil,
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
