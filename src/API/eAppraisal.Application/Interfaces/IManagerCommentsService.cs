using  eAppraisal.Domain.Entities;
using Domain.Shared;

namespace Application.Manager
{
    public interface IManagerCommentsService
    {
        Task<Result<ManagerComments>> AddAsync(ManagerComments comments);
    }
}
