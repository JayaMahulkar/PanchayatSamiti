using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IDesignationService
    {
        Task<bool> AddDesignationAsync(DesignationModel model);
        Task<PaginatedResult<DesignationModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<DesignationModel?> GetByIdAsync(int id);
        Task UpdateAsync(DesignationModel model);
    }
}
