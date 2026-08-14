using Microsoft.AspNetCore.Mvc;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhatePramukhController : ControllerBase
    {
        private readonly IKhatePramukhService _service;

        public KhatePramukhController(IKhatePramukhService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("KhatePramukhs")]
        public async Task<IActionResult> GetAll([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var paged = await _service.GetAllAsync(pageNumber.Value, pageSize.Value);
            return Ok(paged);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] KhatePramukhModel model)
        {
            if (model == null) return BadRequest();
            var result = await _service.AddKhatePramukhAsync(model);
            if (result) return Ok();
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] KhatePramukhModel model)
        {
            if (model == null) return BadRequest();
            var existing = await _service.GetByIdAsync(model.Id);
            if (existing == null) return NotFound();
            await _service.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();
            existing.IsActive = false;
            await _service.UpdateAsync(existing);
            return Ok();
        }
    }
}
