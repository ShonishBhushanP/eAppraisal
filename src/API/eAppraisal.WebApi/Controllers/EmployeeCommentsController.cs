using Microsoft.AspNetCore.Mvc;
using Application.EmployeeFeedback;
using eAppraisal.Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/employee/comments")]
    public class EmployeeCommentsController : ControllerBase
    {
        private readonly IEmployeeCommentsService _service;
        public EmployeeCommentsController(IEmployeeCommentsService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeComments comments)
        {
            var result = await _service.AddAsync(comments);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(new { error = result.Error });
        }
    }
}
