using System.Linq;
using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class VetanShreneeService : IVetanShreneeService
    {
        private readonly IRepository<VetanShreneeMaster> _repository;

        public VetanShreneeService(IRepository<VetanShreneeMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddVetanShreneeAsync(VetanShreneeModel model)
        {
            var entity = new VetanShreneeMaster
            {
                UniqueId = Guid.NewGuid(),
                VetanShrenee = model.VetanShrenee,
                IsActive = model.IsActive ?? true,
                CreatedBy = "Jaya",
                CreatedDate = DateTime.Now,
                UpdatedBy = "Jaya",
                UpdatedDate = DateTime.Now,
                IsDeleted = false
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<List<VetanShreneeModel>> GetAllAsync()
        {
            var list = new List<VetanShreneeModel>();
            var data = await _repository.GetAllAsync(1, int.MaxValue);
            foreach (var item in data.Data)
            {
                list.Add(new VetanShreneeModel
                {
                    Id = item.Id,
                    VetanShrenee = item.VetanShrenee,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                });
            }

            return list;
        }

        public async Task<PaginatedResult<VetanShreneeModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<VetanShreneeModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new VetanShreneeModel
                {
                    Id = item.Id,
                    VetanShrenee = item.VetanShrenee,
                    IsActive = item.IsActive,
                    UniqueId = item.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<VetanShreneeModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return new VetanShreneeModel
            {
                Id = entity.Id,
                VetanShrenee = entity.VetanShrenee,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }

        public async Task UpdateAsync(VetanShreneeModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException("VetanShrenee not found");

            var updated = new VetanShreneeMaster
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
                VetanShrenee = model.VetanShrenee,
                IsActive = model.IsActive ?? existing.IsActive,
                CreatedBy = existing.CreatedBy,
                CreatedDate = existing.CreatedDate,
                UpdatedBy = "Jaya",
                UpdatedDate = DateTime.Now,
                IsDeleted = existing.IsDeleted
            };

            await _repository.UpdateAsync(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return;

            // mark as inactive instead of physical delete
            existing.IsActive = false;
            if (existing is VetanShreneeMaster vm)
            {
                vm.UpdatedBy = "Jaya";
                vm.UpdatedDate = DateTime.Now;
            }

            await _repository.UpdateAsync(existing);
        }
    }
}
