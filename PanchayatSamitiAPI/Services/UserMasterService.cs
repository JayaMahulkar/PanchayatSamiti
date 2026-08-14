using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class UserMasterService : IUserMasterService
    {
        private readonly IRepository<UserMaster> _repository;

        public UserMasterService(IRepository<UserMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddUserAsync(UserModel model)
        {
            var entity = new UserMaster
            {
                Id = model.Id ?? Guid.NewGuid().ToString(),
                Name = model.Name,
                EmailId = model.EmailId,
                Password = model.Password,
                IsActive = model.IsActive ?? true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<UserModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<UserModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new UserModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    EmailId = item.EmailId,
                    IsActive = item.IsActive ?? false,
                    UniqueId = Guid.Empty
                }).ToList()
            };

            return result;
        }

        public async Task<UserModel?> GetByIdAsync(string id)
        {
            var data = await _repository.GetAllAsync(1, 1, x => x.Id == id);
            var item = data.Data.FirstOrDefault();
            if (item == null) return null;

            return new UserModel
            {
                Id = item.Id,
                Name = item.Name,
                EmailId = item.EmailId,
                IsActive = item.IsActive ?? false,
                UniqueId = Guid.Empty
            };
        }

        public async Task UpdateAsync(UserModel model)
        {
            var data = await _repository.GetAllAsync(1, 1, x => x.Id == model.Id);
            var existing = data.Data.FirstOrDefault();
            if (existing == null) throw new ArgumentException("User not found");

            var updated = new UserMaster
            {
                Id = existing.Id,
                Name = model.Name ?? existing.Name,
                EmailId = model.EmailId ?? existing.EmailId,
                Password = model.Password ?? existing.Password,
                IsActive = model.IsActive ?? existing.IsActive,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(updated);
        }
    }
}
