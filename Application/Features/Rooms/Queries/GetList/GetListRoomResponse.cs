using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rooms.Queries.GetList
{
    public class GetListRoomResponse
    {
        public List<Room> Rooms{ get; set; }
    }
}
