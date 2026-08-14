using DataLayer.Models;
using PanchayatSamitiAPI.Model;

namespace PanchayatSamitiAPI.Services.IServices
{
    public interface IBankecheTapshilService
    {
        Task<bool> AddBankecheTapshilAsync(BankecheTapshilModel model);
        Task<PaginatedResult<BankecheTapshilModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<BankecheTapshilModel?> GetByIdAsync(int id);
        Task UpdateAsync(BankecheTapshilModel model);
    }
}
