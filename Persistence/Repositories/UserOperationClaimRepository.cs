using Application.Repositories;
using Core.DataAccess;
using Persistence.Contexts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, HRSDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository (HRSDbContext context) : base(context)
        {
        }
    }
}
