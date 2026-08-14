using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IDepartmentService
    {
        Task<bool> AddDepartmentAsync(DepartmentModel department);
        Task<PaginatedResult<DepartmentModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<DepartmentModel?> GetByIdAsync(int id);
        Task UpdateAsync(DepartmentModel department);

    }
}
