using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IRoleService
    {
        Task<bool> AddRoleAsync(RoleModel model);
        Task<PaginatedResult<RoleModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<RoleModel?> GetByIdAsync(string roleId);
        Task UpdateAsync(RoleModel model);
    }
}
