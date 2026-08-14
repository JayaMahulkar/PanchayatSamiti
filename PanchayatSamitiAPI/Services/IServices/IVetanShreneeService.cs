using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IVetanShreneeService
    {
        Task<bool> AddVetanShreneeAsync(VetanShreneeModel model);
        Task<List<VetanShreneeModel>> GetAllAsync();
        Task<PaginatedResult<VetanShreneeModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<VetanShreneeModel?> GetByIdAsync(int id);
        Task UpdateAsync(VetanShreneeModel model);
        Task DeleteAsync(int id);
    }
}
