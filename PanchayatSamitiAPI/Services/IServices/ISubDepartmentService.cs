using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface ISubDepartmentService
    {
        Task<bool> AddSubDepartmentAsync(SubdepartmentModel subDepartment);        
        Task<PaginatedResult<SubdepartmentModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<SubdepartmentModel?> GetByIdAsync(int id);
        Task UpdateAsync(SubdepartmentModel subDepartment);        
    }
}
