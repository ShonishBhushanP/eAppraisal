using eAppraisal.Domain.Entities;
using Domain.Shared;
using Infrastructure.Repositories;

namespace Application.Manager
{
    public class ManagerCommentsService : IManagerCommentsService
    {
        private readonly IGenericRepository<ManagerComments> _repository;
        public ManagerCommentsService(IGenericRepository<ManagerComments> repository) => _repository = repository;

        public async Task<Result<ManagerComments>> AddAsync(ManagerComments comments)
        {
            if (string.IsNullOrEmpty(comments.Achievements))
                return Result<ManagerComments>.Failure("Achievements are required");

            comments.CreatedAt = DateTime.UtcNow;
            var created = await _repository.AddAsync(comments);
            return Result<ManagerComments>.Success(created);
        }
    }
}
