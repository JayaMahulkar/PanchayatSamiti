using Microsoft.AspNetCore.Mvc;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDepartmentController : ControllerBase
    {
        private readonly ISubDepartmentService _subDepartmentService;

        public SubDepartmentController(ISubDepartmentService subDepartmentService)
        {
            _subDepartmentService = subDepartmentService;
        }

        [HttpGet]
        [Route("SubDepartments")]
        public async Task<IActionResult> GetAllSubDepartments([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var paged = await _subDepartmentService.GetAllAsync(pageNumber.Value, pageSize.Value);
            return Ok(paged);
        }



        [HttpGet]
        [Route("SubDepartments/{id}")]
        public async Task<IActionResult> GetSubDepartmentById(int id)
        {
            var subDepartment = await _subDepartmentService.GetByIdAsync(id);
            if (subDepartment == null)
                return NotFound($"SubDepartment with Id = {id} not found");
            return Ok(subDepartment);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateSubDepartment([FromBody] SubdepartmentModel subDepartment)
        {
            if (subDepartment == null)
                return BadRequest("SubDepartment data is null");

            var result = await _subDepartmentService.GetByIdAsync(subDepartment.Id);

            if (result == null)
                return NotFound($"SubDepartment with Id = {subDepartment.Id} not found");

            await _subDepartmentService.UpdateAsync(subDepartment);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubdepartmentModel subDepartment)
        {
            if (subDepartment == null)
                return BadRequest("SubDepartment data is null");

            var result = await _subDepartmentService.AddSubDepartmentAsync(subDepartment);
            return Ok(result);
        }
        
        
        [HttpDelete]
        [Route("SubDepartments/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSubDepartment = await _subDepartmentService.GetByIdAsync(id);
            if (existingSubDepartment == null)
                return NotFound($"SubDepartment with Id = {id} not found");

            existingSubDepartment.IsActive = false;
            await _subDepartmentService.UpdateAsync(existingSubDepartment);
            return Ok();
        }


    }
}
