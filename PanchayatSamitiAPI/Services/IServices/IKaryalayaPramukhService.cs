using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IKaryalayaPramukhService
    {
        Task<bool> AddKaryalayaPramukhAsync(KaryalayaPramukhModel model);
        Task<PaginatedResult<KaryalayaPramukhModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<KaryalayaPramukhModel?> GetByIdAsync(int id);
        Task UpdateAsync(KaryalayaPramukhModel model);
    }
}
