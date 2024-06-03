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
    public class AllergyRepository : EfRepositoryBase<Allergy, HRSDbContext>, IAllergyRepository
    {
        public AllergyRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
