using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfficeLocation : BaseEntity
    {
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }
        
        public virtual Block Block { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual Room Room { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
