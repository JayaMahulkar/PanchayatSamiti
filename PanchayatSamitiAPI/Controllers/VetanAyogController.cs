using Microsoft.AspNetCore.Mvc;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetanAyogController : ControllerBase
    {
        private readonly IVetanAyogService _service;

        public VetanAyogController(IVetanAyogService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("VetanAyogs")]
        public async Task<IActionResult> GetAllVetanAyogs([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var paged = await _service.GetAllAsync(pageNumber.Value, pageSize.Value);
            return Ok(paged);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVetanAyogById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddVetanAyog([FromBody] VetanAyogModel model)
        {
            if (model == null)
                return BadRequest();

            var result = await _service.AddVetanAyogAsync(model);
            if (result)
                return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateVetanAyog([FromBody] VetanAyogModel model)
        {
            if (model == null)
                return BadRequest();

            var existing = await _service.GetByIdAsync(model.Id);
            if (existing == null)
                return NotFound();

            await _service.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteVetanAyog(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.IsActive = false;
            await _service.UpdateAsync(existing);
            return Ok();
        }
    }
}
