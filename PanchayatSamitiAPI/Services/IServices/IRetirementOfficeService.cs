using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IRetirementOfficeService
    {
        Task<bool> AddRetirementOfficeAsync(RetirementOfficeModel model);
        Task<PaginatedResult<RetirementOfficeModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<RetirementOfficeModel?> GetByIdAsync(int id);
        Task UpdateAsync(RetirementOfficeModel model);
    }
}
