using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AdminRepository : EfRepositoryBase<Admin, HRSDbContext>, IAdminRepository
    {
        public AdminRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
