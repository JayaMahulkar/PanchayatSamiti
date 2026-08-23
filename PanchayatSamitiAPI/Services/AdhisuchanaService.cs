using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class AdhisuchanaService : IAdhisuchanaService
    {
        private readonly IRepository<AdhiSuchanaMaster> _repository;

        public AdhisuchanaService(IRepository<AdhiSuchanaMaster> repository)
        {

            _repository = repository;

        }
        
        public async Task<bool> AddAdhisuchanaAsync(AdhisuchanaModel model)
        {
            try
            {
                var adhisuchanamaster = new AdhiSuchanaMaster
                {

                    UniqueId = Guid.NewGuid(),
                    IsActive = model.IsActive,
                    CreatedBy = "Jaya",
                    UpdatedBy = "Jaya",
                    ModifiedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    EmployeeName = model.EmployeeName,
                    Type = model.Type,
                    TypeName = model.TypeName,
                    Designation = model.Designation,
                    DateOfBirth = model.DateOfBirth,
                    CompletionOfAgeofRetirement5860 = model.CompletionOfAgeofRetirement5860,
                    Class = model.Class,
                    RetirementDate = model.RetirementDate,
                    SandarbhDate = model.SandarbhDate,
                    SandarbhNumber = model.SandarbhNumber,
                    LoginUser = model.LoginUser,
                    EntryDate = DateTime.Now,
                    Status = "pending",
                    FinancialYear = model.FinancialYear,

                };

                return await _repository.AddAsync(adhisuchanamaster);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public async Task<PaginatedResult<AdhisuchanaModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var adhisuchanadata = await _repository.GetAllAsync(pageNumber, pageSize);
            var result = new PaginatedResult<AdhisuchanaModel>
            {
                PageNumber = adhisuchanadata.PageNumber,
                PageSize = adhisuchanadata.PageSize,
                TotalCount = adhisuchanadata.TotalCount,
                Data = adhisuchanadata.Data.Select(item => new AdhisuchanaModel
                {
                    Id = item.Id,
                    UniqueId = item.UniqueId,
                    IsActive = item.IsActive,
                    EmployeeName = item.EmployeeName,
                    Class=item.Class,
                    CompletionOfAgeofRetirement5860=item.CompletionOfAgeofRetirement5860,
                   
                    ModifiedDate=item.ModifiedDate,

                   
                }).ToList(),
            };

            return result;
        }
        
        public async Task<AdhisuchanaModel?> GetByIdAsync(int id)
        {
            var adhisuchanamaster = await _repository.GetByIdAsync(id);
            if (adhisuchanamaster == null)
                return null;
            return new AdhisuchanaModel
            {
                Id = adhisuchanamaster.Id,
                Status = adhisuchanamaster.Status,
                UniqueId = adhisuchanamaster.UniqueId,
                IsActive = adhisuchanamaster.IsActive
            };
        }
        
        public async Task UpdateAsync(AdhisuchanaModel model)
        {
            var existingadhisuchana = await _repository.GetByIdAsync(model.Id);

            if (existingadhisuchana == null)
                throw new ArgumentException("Adhisuchana not found");

            var updateAdhisuchana = new AdhiSuchanaMaster
            {
                Id = model.Id,
                UniqueId = existingadhisuchana.UniqueId,
                IsActive = model.IsActive,
                CreatedBy = "Jaya",
                UpdatedBy = "Jaya",
                ModifiedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                EmployeeName = model.EmployeeName,
                Type = model.Type,
                TypeName = model.TypeName,
                Designation = model.Designation,
                DateOfBirth = model.DateOfBirth,
                CompletionOfAgeofRetirement5860 = model.DateOfBirth,
                Class = model.Class,
                RetirementDate = model.RetirementDate,
                SandarbhDate = model.SandarbhDate,
                SandarbhNumber = model.SandarbhNumber,
                LoginUser = model.LoginUser,
                EntryDate = DateTime.Now,
                Status = "pending",
                FinancialYear = model.FinancialYear,

            };

            await _repository.UpdateAsync(updateAdhisuchana);
        }
    }
}

