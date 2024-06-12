using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Queries.GetListDoctor
{
    public class GetListDoctorResponse
    {
        public DateTime StartTime { get; set; }
        public string Clinic { get; set; }
        public string Doctor { get; set; }
        public string Status { get; set; }
    }
}
