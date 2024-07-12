using Application.Repositories;
using Core.DataAccess;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class WorkingTimeRepository : EfRepositoryBase<WorkingTime, HRSDbContext>, IWorkingTimeRepository
    {
        private readonly HRSDbContext _context;
        public WorkingTimeRepository(HRSDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<WorkingTime?> GetMostRecentAsync(bool asNoTracking = false)
        {
            IQueryable<WorkingTime> queryable = _context.WorkingTimes.OrderByDescending(x => x.Id);

            if (asNoTracking)
                queryable = queryable.AsNoTracking();

            return await queryable.FirstOrDefaultAsync();
        }
    }
}
