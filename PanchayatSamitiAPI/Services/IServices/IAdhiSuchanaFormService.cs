using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IAdhiSuchanaFormService
    {
        Task<bool> AddAdhiSuchanaAsync(AdhiSuchanaFormModel model);
        Task<PaginatedResult<AdhiSuchanaFormModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<AdhiSuchanaFormModel?> GetByIdAsync(int id);
        Task UpdateAsync(AdhiSuchanaFormModel model);

    }
}
