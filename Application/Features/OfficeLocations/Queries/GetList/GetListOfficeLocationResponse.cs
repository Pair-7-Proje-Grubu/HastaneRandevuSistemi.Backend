using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OfficeLocations.Queries.GetList
{
    public class GetListOfficeLocationResponse
    {
        public List<OfficeLocation> OfficeLocations { get; set; }
    }
}
