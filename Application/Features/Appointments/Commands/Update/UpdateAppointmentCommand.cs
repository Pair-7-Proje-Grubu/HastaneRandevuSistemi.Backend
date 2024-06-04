using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentCommand
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public CancelStatus isCancelStatus { get; set; }
    }
}
