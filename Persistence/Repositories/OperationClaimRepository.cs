using Application.Repositories;
using Core.DataAccess;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
