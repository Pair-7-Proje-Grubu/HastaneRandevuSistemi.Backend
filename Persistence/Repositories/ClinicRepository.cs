using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ClinicRepository : EfRepositoryBase<Clinic, HRSDbContext>, IClinicRepository
    {
        public ClinicRepository(HRSDbContext context) : base(context)
        {
        }
    }

}