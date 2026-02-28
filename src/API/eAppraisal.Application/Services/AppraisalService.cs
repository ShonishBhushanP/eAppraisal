using eAppraisal.Domain.Entities;
using Domain.Shared;
using Infrastructure.Repositories;

namespace Application.eAppraisal
{
    public class AppraisalService : IAppraisalService
    {
        private readonly IGenericRepository<Appraisal> _repository;
        public AppraisalService(IGenericRepository<Appraisal> repository) => _repository = repository;

        public async Task<Result<Appraisal>> GetByIdAsync(long id)
        {
            var appraisal = await _repository.GetByIdAsync(id);
            return appraisal == null
                ? Result<Appraisal>.Failure($"Appraisal {id} not found")
                : Result<Appraisal>.Success(appraisal);
        }

        public async Task<Result<Appraisal>> CreateAsync(Appraisal appraisal)
        {
            appraisal.CreatedAt = DateTime.UtcNow;
            var created = await _repository.AddAsync(appraisal);
            return Result<Appraisal>.Success(created);
        }

        public async Task<Result<IEnumerable<Appraisal>>> GetByStatusAsync(long statusId)
        {
            var appraisals = await _repository.FindAsync(a => a.StatusId == statusId);
            return Result<IEnumerable<Appraisal>>.Success(appraisals);
        }
    }
}
