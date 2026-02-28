using Microsoft.AspNetCore.Mvc;
using Application.eAppraisal;
using eAppraisal.Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/appraisals")]
    public class AppraisalController : ControllerBase
    {
        private readonly IAppraisalService _service;
        public AppraisalController(IAppraisalService service) => _service = service;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(new { error = result.Error });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appraisal appraisal)
        {
            var result = await _service.CreateAsync(appraisal);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(new { error = result.Error });
        }

        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> GetByStatus(long statusId)
        {
            var result = await _service.GetByStatusAsync(statusId);
            return Ok(result.Value);
        }
    }
}
