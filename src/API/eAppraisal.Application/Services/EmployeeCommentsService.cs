using eAppraisal.Domain.Entities;
using Domain.Shared;
using Infrastructure.Repositories;

namespace Application.EmployeeFeedback
{
    public class EmployeeCommentsService : IEmployeeCommentsService
    {
        private readonly IGenericRepository<EmployeeComments> _repository;
        public EmployeeCommentsService(IGenericRepository<EmployeeComments> repository) => _repository = repository;

        public async Task<Result<EmployeeComments>> AddAsync(EmployeeComments comments)
        {
            if (string.IsNullOrEmpty(comments.Feedback))
                return Result<EmployeeComments>.Failure("Feedback is required");

            comments.CreatedAt = DateTime.UtcNow;
            var created = await _repository.AddAsync(comments);
            return Result<EmployeeComments>.Success(created);
        }
    }
}
