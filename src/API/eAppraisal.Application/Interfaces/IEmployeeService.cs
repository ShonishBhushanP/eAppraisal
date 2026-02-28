using eAppraisal.Domain.Entities;
using Domain.Shared;

namespace Application.HR
{
    public interface IEmployeeService
    {
        Task<Result<Employee>> GetByIdAsync(long id);
        Task<Result<IEnumerable<Employee>>> GetAllAsync();
        Task<Result<Employee>> AddAsync(Employee employee);
        Task<Result<Employee>> UpdateAsync(Employee employee);
        Task<Result<bool>> DeleteAsync(long id);
    }
}
