using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OfficeLocationRepository : EfRepositoryBase<OfficeLocation, HRSDbContext>, IOfficeLocationRepository
    {
        private readonly HRSDbContext _context;

        public OfficeLocationRepository(HRSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(int blockId, int floorId, int roomId)
        {
            return await _context.Set<OfficeLocation>()
                                .AnyAsync(o => o.BlockId == blockId && o.FloorId == floorId && o.RoomId == roomId);
        }
    }
}
