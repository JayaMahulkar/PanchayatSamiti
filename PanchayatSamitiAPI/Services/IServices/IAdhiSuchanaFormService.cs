using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IAdhiSuchanaService
    {
        Task<bool> AddAdhiSuchanaAsync(AdhiSuchanaModel model);
        Task<PaginatedResult<AdhiSuchanaModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<AdhiSuchanaModel?> GetByIdAsync(int id);
        Task UpdateAsync(AdhiSuchanaModel model);

    }
}
