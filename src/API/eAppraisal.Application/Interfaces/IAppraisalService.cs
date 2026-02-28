using eAppraisal.Domain.Entities;
using Domain.Shared;

namespace Application.eAppraisal
{
    public interface IAppraisalService
    {
        Task<Result<Appraisal>> GetByIdAsync(long id);
        Task<Result<Appraisal>> CreateAsync(Appraisal appraisal);
        Task<Result<IEnumerable<Appraisal>>> GetByStatusAsync(long statusId);
    }
}
