using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TitleRepository : EfRepositoryBase<Title, HRSDbContext>, ITitleRepository
    {
        public TitleRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
