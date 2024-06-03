using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public CancelStatus isCancelStatus { get; set; } = CancelStatus.NoCancel;
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
       

    }
    public enum CancelStatus
    {
        NoCancel = 0,
        FromDoctor = 1,
        FromPatient = 2,
    }
}
