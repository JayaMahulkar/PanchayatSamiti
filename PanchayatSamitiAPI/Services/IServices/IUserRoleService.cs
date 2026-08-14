using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IUserRoleService
    {
        Task<bool> AddUserRoleAsync(UserRoleModel model);
        Task<PaginatedResult<UserRoleModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<UserRoleModel?> GetByIdAsync(string id);
        Task UpdateAsync(UserRoleModel model);
    }
}
