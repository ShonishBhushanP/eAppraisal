using Microsoft.AspNetCore.Mvc;
using Application.Manager;
using eAppraisal.Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/manager/comments")]
    public class ManagerCommentsController : ControllerBase
    {
        private readonly IManagerCommentsService _service;
        public ManagerCommentsController(IManagerCommentsService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Add(ManagerComments comments)
        {
            var result = await _service.AddAsync(comments);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(new { error = result.Error });
        }
    }
}
