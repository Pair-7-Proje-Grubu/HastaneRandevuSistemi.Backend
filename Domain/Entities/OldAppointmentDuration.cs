using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OldAppointmentDuration  : BaseEntity
    {
        public int ClinicId {  get; set; }  
        public int Duration { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
