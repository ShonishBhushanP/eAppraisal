using eAppraisal.Domain.Entities;
using Domain.Shared;
using Infrastructure.Repositories;

namespace Application.HR
{
    public class UserLoginService: IUserLoginService
    {
        private readonly IGenericRepository<UserLogin> _repository;
        public UserLoginService(IGenericRepository<UserLogin> repository) => _repository = repository;

        public async Task<Result<UserLogin>> AuthenticateAsync(string username, string passwordHash)
        {
            var users = await _repository.FindAsync(u => u.Username == username && u.PasswordHash == passwordHash);
            var user = users.FirstOrDefault();
            return user == null
                ? Result<UserLogin>.Failure("Invalid credentials")
                : Result<UserLogin>.Success(user);
        }

        public async Task<Result<UserLogin>> LockAccountAsync(long userId)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user == null)
                return Result<UserLogin>.Failure($"User {userId} not found");

            user.IsLocked = true;
            var updated = await _repository.UpdateAsync(user);
            return Result<UserLogin>.Success(updated ?? new());
        }
    }
}
