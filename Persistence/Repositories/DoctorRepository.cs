using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class DoctorRepository : EfRepositoryBase<Doctor, HRSDbContext>, IDoctorRepository
    {
        public DoctorRepository(HRSDbContext context) : base(context)
        {

        }
    }

}
