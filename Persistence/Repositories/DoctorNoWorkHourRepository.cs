using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class DoctorNoWorkHourRepository : EfRepositoryBase<DoctorNoWorkHour, HRSDbContext>, IDoctorNoWorkHourRepository
    {
        public DoctorNoWorkHourRepository(HRSDbContext context) : base(context)
        {
        }
    }
}
