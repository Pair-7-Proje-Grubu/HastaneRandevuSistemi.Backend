using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListPatientByDoctor
{
    public class GetListPatientByDoctorResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? BloodType { get; set; }
        public string? EmergencyContact {  get; set; }
    }
}
