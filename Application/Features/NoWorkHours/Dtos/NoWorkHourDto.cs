using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Dtos
{
    public class NoWorkHourDto 
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isFullDay { get; set; } = false;
    }
}
