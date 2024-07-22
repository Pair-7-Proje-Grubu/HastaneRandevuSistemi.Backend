using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IBlockRepository : IAsyncRepository<Block>, IRepository<Block>
    {
    }
    
}
