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
        public WorkingTimeRepository(HRSDbContext context) : base(context)
        {
        }
    }
}
