using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RoomRepository : EfRepositoryBase<Room, HRSDbContext>, IRoomRepository
    {
        public RoomRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
