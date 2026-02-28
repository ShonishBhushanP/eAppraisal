using eAppraisal.Domain.Entities;
using Domain.Shared;

namespace Application.HR
{
    public interface IUserLoginService
    {
        Task<Result<UserLogin>> AuthenticateAsync(string username, string passwordHash);
        Task<Result<UserLogin>> LockAccountAsync(long userId);
    }
}
