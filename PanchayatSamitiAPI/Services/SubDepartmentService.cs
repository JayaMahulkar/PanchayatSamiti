using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class SubDepartmentService : ISubDepartmentService
    {
        private readonly IRepository<SubDepartmentMaster> _repository;
        public SubDepartmentService(IRepository<SubDepartmentMaster> repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddSubDepartmentAsync(SubdepartmentModel subDepartment)
        {
            var subdepartmentMaster = new SubDepartmentMaster
            {
               
                SubDepartmentName = subDepartment.SubDepartmentName,
                IsActive = subDepartment.IsActive,
                UniqueId = Guid.NewGuid(),
                CreatedBy = 1,
                UpdatedBy=1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            return await _repository.AddAsync(subdepartmentMaster);

        }
        public async Task UpdateAsync(SubdepartmentModel subDepartment)
        {
          var existingSubDepartment = await _repository.GetByIdAsync(subDepartment.Id);
            if (existingSubDepartment == null) 
               throw new InvalidOperationException("SubDepartmentrecord is not present");

            var subdepartmentMaster = new SubDepartmentMaster
            {
                Id = subDepartment.Id,
                IsActive = subDepartment.IsActive,
                SubDepartmentName = subDepartment.SubDepartmentName,
                UniqueId=existingSubDepartment.UniqueId,
                CreatedBy = existingSubDepartment.CreatedBy,
                UpdatedBy =existingSubDepartment.UpdatedBy,
                CreatedDate = existingSubDepartment.CreatedDate,
                ModifiedDate = DateTime.Now
            };
             await _repository.UpdateAsync(subdepartmentMaster);


        }

      

        public async Task<PaginatedResult<SubdepartmentModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<SubdepartmentModel>
            {
                PageNumber = data.PageNumber,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Data = data.Data.Select(subDepartment => new SubdepartmentModel
                {
                    Id = subDepartment.Id,
                    SubDepartmentName = subDepartment.SubDepartmentName,
                    IsActive = subDepartment.IsActive,
                    UniqueId = subDepartment.UniqueId
                }).ToList()
            };

            return result;
        }

        public async Task<SubdepartmentModel?> GetByIdAsync(int id)
        {
            var subDepartment = await _repository.GetByIdAsync(id);
            if (subDepartment == null) return null;

            return new SubdepartmentModel
            {
                Id = subDepartment.Id,
                SubDepartmentName = subDepartment.SubDepartmentName,
                IsActive = subDepartment.IsActive,
                UniqueId = subDepartment.UniqueId
            };
        
        }       
    }
}
