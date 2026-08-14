using Microsoft.AspNetCore.Mvc;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("Departments")]
        public async Task<IActionResult> GetAllDepartments([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var paged = await _departmentService.GetAllAsync(pageNumber.Value, pageSize.Value);
            return Ok(paged);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentModel department)
        {
            if (department == null)
                return BadRequest();

            var result = await _departmentService.AddDepartmentAsync(department);
            if (result)
                return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentModel department)
        {
            if (department == null)
                return BadRequest();

            var existingDepartment = await _departmentService.GetByIdAsync(department.Id);
            if (existingDepartment == null)
                return NotFound();

            await _departmentService.UpdateAsync(department);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var existingDepartment = await _departmentService.GetByIdAsync(id);
            if (existingDepartment == null)
                return NotFound();

            existingDepartment.IsActive = false;
            
            await _departmentService.UpdateAsync(existingDepartment);
            return Ok();
        }

    }
}
