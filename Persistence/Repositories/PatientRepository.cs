using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class PatientRepository : EfRepositoryBase<Patient, HRSDbContext>, IPatientRepository
    {
        public PatientRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
