using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Commands.Queries.GetListClinic
{
    public class GetListClinicResponse
    {
        public List<Clinic> Clinics { get; set; }
    }
}
