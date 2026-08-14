using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IKhatePramukhService
    {
        Task<bool> AddKhatePramukhAsync(KhatePramukhModel model);
        Task<PaginatedResult<KhatePramukhModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<KhatePramukhModel?> GetByIdAsync(int id);
        Task UpdateAsync(KhatePramukhModel model);
    }
}
