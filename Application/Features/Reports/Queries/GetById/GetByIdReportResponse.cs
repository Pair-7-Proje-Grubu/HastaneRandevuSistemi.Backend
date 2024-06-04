using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Queries.GetById
{
    public class GetByIdReportResponse
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public string Description { get; set; }
    }
}
