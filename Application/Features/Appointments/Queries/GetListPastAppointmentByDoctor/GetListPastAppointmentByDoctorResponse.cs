using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListPastAppointmentByDoctor
{
    public class GetListPastAppointmentByDoctorResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodType { get; set; }
        public string AppointmentDate { get; set; }
    }
}
