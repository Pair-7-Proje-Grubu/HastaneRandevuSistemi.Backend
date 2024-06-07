using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities
{
    public class OperationClaim : Core.Entities.OperationClaim
    {
        public virtual ICollection<OperationClaim> OperationClaims { get; set; }
    }
}
