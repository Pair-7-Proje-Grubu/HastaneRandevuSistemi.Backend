using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListActiveAppointment
{
    public class GetListActiveAppointmentByDoctorResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
