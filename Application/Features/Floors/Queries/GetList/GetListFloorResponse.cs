using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Floors.Queries.GetList
{
    public class GetListFloorResponse
    {
        public List<Floor> Floors { get; set; }
    }
}
