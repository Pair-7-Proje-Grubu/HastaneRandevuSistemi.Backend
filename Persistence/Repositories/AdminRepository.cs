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
    public class AdminRepository : EfRepositoryBase<Admin, HRSDbContext>, IAdminRepository
    {
        public AdminRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
