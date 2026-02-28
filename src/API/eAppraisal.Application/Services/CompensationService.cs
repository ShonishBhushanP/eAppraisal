using eAppraisal.Domain.Entities;
using Domain.Shared;
using Infrastructure.Repositories;

namespace Application.Compensations
{
    public class CompensationService : ICompensationService
    {
        private readonly IGenericRepository<Compensation> _repository;
        public CompensationService(IGenericRepository<Compensation> repository) => _repository = repository;

        public async Task<Result<Compensation>> UpdateAsync(Compensation comp)
        {
            var existing = await _repository.GetByIdAsync(comp.CompensationId);
            if (existing == null)
                return Result<Compensation>.Failure($"Compensation {comp.CompensationId} not found");

            existing.BasicSalary = comp.BasicSalary;
            existing.Promoted = comp.Promoted;
            existing.ModifyAt = DateTime.UtcNow;

            var updated = await _repository.UpdateAsync(existing) ?? new();
            return Result<Compensation>.Success(updated);
        }
    }
}
