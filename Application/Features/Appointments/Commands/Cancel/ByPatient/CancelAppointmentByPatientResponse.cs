using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Cancel.ByPatient
{
    public class CancelAppointmentByPatientResponse
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
