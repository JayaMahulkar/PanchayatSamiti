using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IAdhisuchanaService
    {
    
        Task<bool> AddAdhisuchanaAsync(AdhisuchanaModel model);
        Task<PaginatedResult<AdhisuchanaModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<AdhisuchanaModel?> GetByIdAsync(int id);
        Task UpdateAsync(AdhisuchanaModel model);
    }
}
