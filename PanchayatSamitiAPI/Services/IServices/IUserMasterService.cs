using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IUserMasterService
    {
        Task<bool> AddUserAsync(UserModel model);
        Task<PaginatedResult<UserModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<UserModel?> GetByIdAsync(string id);
        Task UpdateAsync(UserModel model);
    }
}
