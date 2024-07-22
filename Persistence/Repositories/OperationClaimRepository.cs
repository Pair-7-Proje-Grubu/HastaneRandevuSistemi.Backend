using Application.Repositories;
using Core.DataAccess;
using Persistence.Contexts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, HRSDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(HRSDbContext context) : base(context)
        {
        }
    }
}
