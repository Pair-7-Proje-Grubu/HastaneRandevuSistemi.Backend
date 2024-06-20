using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListActiveAppointment
{
    public class GetListActiveAppointmentByDoctorResponse
    {
        public DateTime DateTime { get; set; }
        public string OfficeLocation { get; set; }
        public string DoctorName { get; set; }
        public string ClinicName { get; set; }
    }
}
