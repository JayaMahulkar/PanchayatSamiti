using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<RoleMaster> _repository;

        public RoleService(IRepository<RoleMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddRoleAsync(RoleModel model)
        {
            var entity = new RoleMaster
            {
                RoleId = model.RoleId ?? Guid.NewGuid().ToString(),
                Role = model.Role ?? string.Empty,
                IsActive = model.IsActive ?? true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<PaginatedResult<RoleModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<RoleModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new RoleModel
                {
                    RoleId = item.RoleId,
                    Role = item.Role,
                    IsActive = item.IsActive ?? false,
                    UniqueId = Guid.Empty
                }).ToList()
            };

            return result;
        }

        public async Task<RoleModel?> GetByIdAsync(string roleId)
        {
            // repository GetByIdAsync expects int id; use GetAllAsync with filter
            var data = await _repository.GetAllAsync(1, 1, x => x.RoleId == roleId);
            var item = data.Data.FirstOrDefault();
            if (item == null) return null;

            return new RoleModel
            {
                RoleId = item.RoleId,
                Role = item.Role,
                IsActive = item.IsActive,
                UniqueId = Guid.Empty
            };
        }

        public async Task UpdateAsync(RoleModel model)
        {
            var data = await _repository.GetAllAsync(1, 1, x => x.RoleId == model.RoleId);
            var existing = data.Data.FirstOrDefault();
            if (existing == null) throw new ArgumentException("Role not found");

            var updated = new RoleMaster
            {
                RoleId = existing.RoleId,
                Role = model.Role ?? existing.Role,
                IsActive = model.IsActive ?? existing.IsActive,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(updated);
        }
    }
}
