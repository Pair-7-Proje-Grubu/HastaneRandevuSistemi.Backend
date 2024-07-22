using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, HRSDbContext>, IUserRepository
    {
        public UserRepository(HRSDbContext context) : base(context)
        {

        }
    }

}
