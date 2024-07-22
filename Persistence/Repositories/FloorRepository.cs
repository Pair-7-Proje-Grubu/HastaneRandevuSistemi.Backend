using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class FloorRepository : EfRepositoryBase<Floor, HRSDbContext>, IFloorRepository
    {
        public FloorRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
