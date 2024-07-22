using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AppointmentRepository : EfRepositoryBase<Appointment, HRSDbContext>, IAppointmentRepository
    {
        public AppointmentRepository(HRSDbContext context) : base(context)
        {
        }

    }

}
