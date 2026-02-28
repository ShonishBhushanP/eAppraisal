using eAppraisal.Domain.Entities;
using Domain.Shared;
using Infrastructure.Repositories;

namespace Application.HR
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        public EmployeeService(IGenericRepository<Employee> repository) => _repository = repository;

        public async Task<Result<Employee>> GetByIdAsync(long id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return employee == null
                ? Result<Employee>.Failure($"Employee {id} not found")
                : Result<Employee>.Success(employee);
        }

        public async Task<Result<IEnumerable<Employee>>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return Result<IEnumerable<Employee>>.Success(employees);
        }

        public async Task<Result<Employee>> AddAsync(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
                return Result<Employee>.Failure("Name is required");

            employee.AddedAt = DateTime.UtcNow;
            var created = await _repository.AddAsync(employee);
            return Result<Employee>.Success(created);
        }

        public async Task<Result<Employee>> UpdateAsync(Employee employee)
        {
            var updated = await _repository.UpdateAsync(employee);
            return updated == null
                ? Result<Employee>.Failure($"Employee {employee.EmployeeId} not found")
                : Result<Employee>.Success(updated);
        }

        public async Task<Result<bool>> DeleteAsync(long id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted
                ? Result<bool>.Success(true)
                : Result<bool>.Failure($"Employee {id} not found");
        }
    }
}
