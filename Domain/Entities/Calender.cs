using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Calender : BaseEntity
    {
        //TODO
        public DateTime Date { get; set; }
        public bool IsHolidayDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

    }
}
