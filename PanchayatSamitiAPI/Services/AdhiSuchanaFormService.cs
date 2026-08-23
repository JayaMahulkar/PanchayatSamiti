using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{   
    public class AdhiSuchanaFormService : IAdhiSuchanaFormService
    {
        private readonly IRepository<AdhiSuchanaForm> _repository;

        public AdhiSuchanaFormService(IRepository<AdhiSuchanaForm> repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddAdhiSuchanaAsync(AdhiSuchanaFormModel model)
        {
            var entity = new AdhiSuchanaForm
            {
               EmployeeName=model.EmployeeName,
               TypeId=model.TypeId,
               PanchayatSamitiId=model.Id,
               DesignationId=model.DesignationId,
               DateOfBirth= DateOnly.FromDateTime(DateTime.Now),
               ClassId=1,
               DateforCompletion= DateOnly.FromDateTime(DateTime.Now),
               DateOfRetirement= DateOnly.FromDateTime(DateTime.Now),
              
               ReferenceDate= DateOnly.FromDateTime(DateTime.Now),
               ReferenceNumber=model.ReferenceNumber,
               CreatedBy="Jaya",
               UpdatedBy="JAya",
               CreatedDate=DateTime.Now,
               UpdatedDate=DateTime.Now,
               UniqueId=Guid.NewGuid(),
               IsActive = true,


            };
          return await  _repository.AddAsync(entity);
        }
           
      

        public async Task<PaginatedResult<AdhiSuchanaFormModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<AdhiSuchanaFormModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(item => new AdhiSuchanaFormModel
                {
                    Id = item.Id,
                    UniqueId=item.UniqueId,
                    IsActive=item.IsActive,
                    EmployeeName=item.EmployeeName

                }).ToList()
            };

            return result;
        }

        public async Task<AdhiSuchanaFormModel?> GetByIdAsync(int id)
        {
               
         var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;
            
            return new AdhiSuchanaFormModel
            {
                Id = entity.Id,
                EmployeeName = entity.EmployeeName,
                IsActive = entity.IsActive,
                UniqueId = entity.UniqueId
            };
        }



        

        public async Task UpdateAsync(AdhiSuchanaFormModel model)
        {
            var existing = await _repository.GetByIdAsync(model.Id);
            if (existing == null)
                throw new ArgumentException(" not found");
            var updated = new AdhiSuchanaForm
            {
                Id = model.Id,
                UniqueId = existing.UniqueId,
               EmployeeName=model.EmployeeName,
                IsActive = model.IsActive ?? true,              /*model.IsActive ?? existing.IsActive,*/
                CreatedBy = existing.CreatedBy,
                CreatedDate = existing.CreatedDate,
                UpdatedBy = "System",
                UpdatedDate = DateTime.Now,
            };
                                                                                
            await _repository.UpdateAsync(updated);
            }

         
        }
    }

