using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRepository<UserRole> _repository;

        public UserRoleService(IRepository<UserRole> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddUserRoleAsync(UserRoleModel model)
        {
            var entity = new UserRole
            {
                Id = model.Id ?? Guid.NewGuid().ToString(),
                UserId = model.UserId ?? string.Empty,
                RoleId = model.RoleId ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<UserRoleModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<UserRoleModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new UserRoleModel
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    RoleId = item.RoleId,
                    IsActive = item.IsActive
                }).ToList()
            };

            return result;
        }

        public async Task<UserRoleModel?> GetByIdAsync(string id)
        {
            var data = await _repository.GetAllAsync(1, 1, x => x.Id == id);
            var item = data.Data.FirstOrDefault();
            if (item == null) return null;

            return new UserRoleModel
            {
                Id = item.Id,
                UserId = item.UserId,
                RoleId = item.RoleId,
                IsActive = item.IsActive
            };
        }

        public async Task UpdateAsync(UserRoleModel model)
        {
            var data = await _repository.GetAllAsync(1, 1, x => x.Id == model.Id);
            var existing = data.Data.FirstOrDefault();
            if (existing == null) throw new ArgumentException("UserRole not found");

            var updated = new UserRole
            {
                Id = existing.Id,
                UserId = model.UserId ?? existing.UserId,
                RoleId = model.RoleId ?? existing.RoleId,
                IsActive = model.IsActive ?? existing.IsActive,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(updated);
        }
    }
}
