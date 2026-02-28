using eAppraisal.Domain.Entities;
using Domain.Shared;

namespace Application.EmployeeFeedback
{
    public interface IEmployeeCommentsService
    {
        Task<Result<EmployeeComments>> AddAsync(EmployeeComments comments);
    }
}
