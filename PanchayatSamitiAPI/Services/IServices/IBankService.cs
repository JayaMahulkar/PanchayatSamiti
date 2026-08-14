using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IBankService
    {
        Task<bool> AddBankAsync(BankModel model);
        Task<PaginatedResult<BankModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<BankModel?> GetByIdAsync(int id);
        Task UpdateAsync(BankModel model);
    }
}
