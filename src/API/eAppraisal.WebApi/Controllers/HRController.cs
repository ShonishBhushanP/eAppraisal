using Microsoft.AspNetCore.Mvc;
using Application.HR;
using eAppraisal.Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/hr")]
    public class HRController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public HRController(IEmployeeService employeeService) => _employeeService = employeeService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(long id)
        {
            var result = await _employeeService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(new { error = result.Error });
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeService.GetAllAsync();
            return Ok(result.Value);
        }

        [HttpPost("employees")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _employeeService.AddAsync(employee);
            return result.IsSuccess
                ? CreatedAtAction(nameof(GetEmployee), new { id = result.Value.EmployeeId }, result.Value)
                : BadRequest(new { error = result.Error });
        }

        [HttpPut("employees")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var result = await _employeeService.UpdateAsync(employee);
            return result.IsSuccess ? Ok(result.Value) : NotFound(new { error = result.Error });
        }

        [HttpDelete("employees/{id}")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            var result = await _employeeService.DeleteAsync(id);
            return result.IsSuccess ? Ok(new { success = true }) : NotFound(new { error = result.Error });
        }
    }
}
