using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanchayatSamitiAPI.Model;
using PanchayatSamitiAPI.Services;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdhiSuchanaFormController : ControllerBase
    { 
        private readonly IAdhiSuchanaFormService _adhiSuchanaFormServise;
        public AdhiSuchanaFormController(IAdhiSuchanaFormService adhiSuchanaFormService) 
        {
        _adhiSuchanaFormServise= adhiSuchanaFormService;
        
        }
        [HttpGet]
       
        public async Task<IActionResult> GetAll([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var paged = await _adhiSuchanaFormServise.GetAllAsync(pageNumber.Value, pageSize.Value);
            return Ok(paged);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AdhiSuchanaFormModel model)
        {
            if (model == null) return BadRequest();
            var result = await _adhiSuchanaFormServise.AddAdhiSuchanaAsync(model);
            if (result) return Ok();
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


            [HttpPut]
            [Route("Update")]
            public async Task<IActionResult> Update([FromBody] AdhiSuchanaFormModel model)
            {
                if (model == null) return BadRequest();
                var existing = await _adhiSuchanaFormServise.GetByIdAsync(model.Id);
                if (existing == null) return NotFound();
                await _adhiSuchanaFormServise.UpdateAsync(model);
                return Ok();
            }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _adhiSuchanaFormServise.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var existing = await _adhiSuchanaFormServise.GetByIdAsync(id);
                if (existing == null) return NotFound();
                existing.IsActive = false;
                await _adhiSuchanaFormServise.UpdateAsync(existing);
                return Ok();
            }

        }
}
