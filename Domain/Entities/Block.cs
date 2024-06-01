using Core.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Block : BaseEntity
    {
        public string No { get; set; }
        public virtual ICollection<OfficeLocation> OfficeLocations { get; set; }

    }
}
