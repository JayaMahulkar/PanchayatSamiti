
using DataLayer.Models;
using DataLayer.Repository;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<DepartmentMaster> _repository;

        public DepartmentService(IRepository<DepartmentMaster> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddDepartmentAsync(DepartmentModel departmentModel)
        {
            //Business Logic
            var departmentMaster = new DepartmentMaster
            {
                UniqueId = Guid.NewGuid(),
                DepartmentName = departmentModel.DepartmentName,
                IsActive = departmentModel.IsActive ?? true,
                Createdby = "Jaya",
                UpdatedBy="Jaya",
                ModifiedDate=DateTime.Now,
                CreatedDate=DateTime.Now

            };
            return await _repository.AddAsync(departmentMaster );
        }

        public async Task<PaginatedResult<DepartmentModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var departmentData = await _repository.GetAllAsync(pageNumber, pageSize);

            var result = new PaginatedResult<DepartmentModel>
            {
                PageNumber = departmentData.PageNumber,
                PageSize = departmentData.PageSize,
                TotalCount = departmentData.TotalCount,
                Data = departmentData.Data.Select(item => new DepartmentModel
                {
                    Id = item.Id,
                    DepartmentName = item.DepartmentName,
                    IsActive = item.IsActive, 
                    CreatedDate = item.ModifiedDate,
                    UniqueId = item.UniqueId
                }).OrderByDescending(a=>a.CreatedDate).ToList()
            };

            return result;
        }

        public async Task<DepartmentModel?> GetByIdAsync(int id)
        {
            var departmentMaster = await _repository.GetByIdAsync(id);
            if(departmentMaster == null)
                return null;

            return new DepartmentModel
            {
                Id = departmentMaster.Id,
                DepartmentName = departmentMaster.DepartmentName,
                IsActive = departmentMaster.IsActive,
                UniqueId = departmentMaster.UniqueId
            };
        }

        public async Task UpdateAsync(DepartmentModel department)
        {
            var existingDepartment = await _repository.GetByIdAsync(department.Id);
           
            if (existingDepartment == null)
                throw new ArgumentException("Department not found");
           
            var updatedDepartment = new DepartmentMaster
            {
                Id = department.Id,
                UniqueId = existingDepartment.UniqueId,
                DepartmentName = department.DepartmentName,
                IsActive = department.IsActive??true,
                Createdby= existingDepartment.Createdby,
                CreatedDate = existingDepartment.CreatedDate,
                UpdatedBy = "Jaya",
                ModifiedDate = DateTime.Now,
            };

            await _repository.UpdateAsync(updatedDepartment);
        }
        
    }
}
