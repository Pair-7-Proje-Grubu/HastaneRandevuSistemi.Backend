using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
    {
    }
}
