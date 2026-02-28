using Microsoft.AspNetCore.Mvc;
using Application.Compensations;
using eAppraisal.Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ICompensationService _service;
        public CompensationController(ICompensationService service) => _service = service;

        [HttpPut]
        public async Task<IActionResult> Update(Compensation comp)
        {
            var result = await _service.UpdateAsync(comp);
            return result.IsSuccess ? Ok(result.Value) : NotFound(new { error = result.Error });
        }
    }
}
