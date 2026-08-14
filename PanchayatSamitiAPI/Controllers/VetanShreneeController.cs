using Microsoft.AspNetCore.Mvc;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetanShreneeController : ControllerBase
    {
        private readonly IVetanShreneeService _service;

        public VetanShreneeController(IVetanShreneeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("VetanShrenees")]
        public async Task<IActionResult> GetAll([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            if (pageNumber.HasValue && pageSize.HasValue && pageSize.Value > 0)
            {
                var paged = await _service.GetAllAsync(pageNumber.Value, pageSize.Value);
                return Ok(paged);
            }

            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VetanShreneeModel model)
        {
            if (model == null)
                return BadRequest();

            var result = await _service.AddVetanShreneeAsync(model);
            if (result)
                return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VetanShreneeModel model)
        {
            if (model == null)
                return BadRequest();

            var existing = await _service.GetByIdAsync(model.Id);
            if (existing == null)
                return NotFound();

            await _service.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
