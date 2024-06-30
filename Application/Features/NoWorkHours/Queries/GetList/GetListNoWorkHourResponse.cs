using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Queries.GetList
{
    public class GetListNoWorkHourResponse
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }

        #region non-used
        //public int Id { get; set; }

        //public DateTime DateTime { get; set; } 
        #endregion
    }
}
