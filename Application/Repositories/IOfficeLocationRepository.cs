using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IOfficeLocationRepository : IAsyncRepository<OfficeLocation>, IRepository<OfficeLocation>
    {
        Task<bool> ExistsAsync(int blockId, int floorId, int roomId);
    }
}
