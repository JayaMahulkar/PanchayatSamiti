using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdhisuchanaController : ControllerBase
    {
        private readonly IAdhisuchanaService _adhisuchanaService;

        public AdhisuchanaController(IAdhisuchanaService adhisuchanaService)
        {

            _adhisuchanaService = adhisuchanaService;

        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddAdhisuchana([FromBody] AdhisuchanaModel model)
        {
            if (model == null)
                return BadRequest();

            var result = await _adhisuchanaService.AddAdhisuchanaAsync(model);
            if (result)
                return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAdhisuchana([FromQuery] int? pageNumber, [FromQuery] int? pageSize)

        {
            var paged = await _adhisuchanaService.GetAllAsync(pageNumber.Value, pageSize.Value);
            return Ok(paged);


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdhisuchanaById(int id)
        {
            var adhisuchanadata = await _adhisuchanaService.GetByIdAsync(id);
            if (adhisuchanadata == null)
                return NotFound();

            return Ok(adhisuchanadata);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> UpdateAdhisuchana([FromBody] AdhisuchanaModel model)

        {
            if (model == null)
                return BadRequest();

            var existingAdhisuchana = await _adhisuchanaService.GetByIdAsync(model.Id);
            if (existingAdhisuchana == null)
                return NotFound();

            await _adhisuchanaService.UpdateAsync(model);
            return Ok();
        }
            [HttpDelete]
            [Route("Delete/{id}")]
            public async Task<IActionResult> DeleteDepartment(int id)
            {
                var existingAdhisuchana = await _adhisuchanaService.GetByIdAsync(id);
                if (existingAdhisuchana == null)
                    return NotFound();

            existingAdhisuchana.IsActive = false;

                await _adhisuchanaService.UpdateAsync(existingAdhisuchana);
                return Ok();
            }
        
    }
}