using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Common
{
    public interface IPaginationParams
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}
