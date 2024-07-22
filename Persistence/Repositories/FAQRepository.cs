using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class FAQRepository : EfRepositoryBase<FAQ, HRSDbContext>, IFAQRepository
    {
        public FAQRepository(HRSDbContext context) : base(context)
        {
        }
    }
}
