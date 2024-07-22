using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class NoWorkHourRepository : EfRepositoryBase<NoWorkHour, HRSDbContext>, INoWorkHourRepository
    {
        public NoWorkHourRepository(HRSDbContext context) : base(context)
        {
        }
    }
}
