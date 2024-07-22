using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IFloorRepository : IAsyncRepository<Floor>, IRepository<Floor>
    {
    }
    
}
