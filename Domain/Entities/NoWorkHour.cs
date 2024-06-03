using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NoWorkHour : BaseEntity
    {
        public DateTime DateTime;

        public virtual Doctor Doctor { get; set; }
    }
}
