using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Cancel.FromDoctor
{
    public class CancelAppointmentFromDoctorResponse
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public DateTime DateTime { get; set; }
        public CancelStatus isCancelStatus { get; set; }
    }
}
