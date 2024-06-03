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
    public class ClinicRepository : EfRepositoryBase<Clinic, HRSDbContext>, IClinicRepository
    {
        public ClinicRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
