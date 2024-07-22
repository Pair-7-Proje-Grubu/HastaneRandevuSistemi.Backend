using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IRoomRepository : IAsyncRepository<Room>, IRepository<Room>
    {
    }
    
}
