using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WorkingTimes.Queries.GetList
{
    public class GetListWorkingTimeResponse
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartBreakTime { get; set; }
        public TimeSpan EndBreakTime { get; set; }
    }
}
