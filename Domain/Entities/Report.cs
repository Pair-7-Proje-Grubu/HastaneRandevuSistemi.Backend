using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Report : BaseEntity
    {
        public int AppointmentId { get; set; }
        public string Description { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
