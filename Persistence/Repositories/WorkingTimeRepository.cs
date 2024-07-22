using Application.Repositories;
using Core.DataAccess;
using Persistence.Contexts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class WorkingTimeRepository : EfRepositoryBase<WorkingTime, HRSDbContext>, IWorkingTimeRepository
    {
        public WorkingTimeRepository(HRSDbContext context) : base(context)
        {
        }
    }
}
