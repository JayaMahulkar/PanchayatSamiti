using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IKharchacheShirshService
    {
        Task<bool> AddKharchacheShirshAsync(KharchacheShirshModel model);
        Task<PaginatedResult<KharchacheShirshModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<KharchacheShirshModel?> GetByIdAsync(int id);
        Task UpdateAsync(KharchacheShirshModel model);
    }
}
