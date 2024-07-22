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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClinicName { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
    }
}
