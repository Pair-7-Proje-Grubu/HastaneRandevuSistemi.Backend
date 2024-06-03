using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class FloorRepository : EfRepositoryBase<Floor, HRSDbContext>, IFloorRepository
    {
        public FloorRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
