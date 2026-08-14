using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IRelationService
    {
        Task<bool> AddRelationAsync(RelationModel model);
        Task<PaginatedResult<RelationModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<RelationModel?> GetByIdAsync(int id);
        Task UpdateAsync(RelationModel model);
    }
}
