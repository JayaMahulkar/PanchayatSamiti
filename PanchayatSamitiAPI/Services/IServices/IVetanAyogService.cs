using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IVetanAyogService
    {
        Task<bool> AddVetanAyogAsync(VetanAyogModel model);
        Task<PaginatedResult<VetanAyogModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<VetanAyogModel?> GetByIdAsync(int id);
        Task UpdateAsync(VetanAyogModel model);
    }
}
