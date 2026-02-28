using eAppraisal.Domain.Entities;
using Domain.Shared;

namespace Application.Compensations
{
    public interface ICompensationService
    {
        Task<Result<Compensation>> UpdateAsync(Compensation comp);
    }
}
