using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BlockRepository : EfRepositoryBase<Block, HRSDbContext>, IBlockRepository
    {
        public BlockRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
