using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AllergyRepository : EfRepositoryBase<Allergy, HRSDbContext>, IAllergyRepository
    {
        public AllergyRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
