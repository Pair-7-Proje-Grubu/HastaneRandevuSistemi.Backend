using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Commands.Create
{
    public class CreateNoWorkHourResponse
    {
        //public int Id { get; set; } // DoctorId ?

        //public DateTime DateTime { get; set; }

        public int Id { get; set; }

        public int DoctorId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsFullDay { get; set; }
    }
}
