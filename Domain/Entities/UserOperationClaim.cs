using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserOperationClaim : Core.Entities.UserOperationClaim
    {
        public virtual BaseUser User {  get; set; }
        public virtual OperationClaim OperationClaim { get; set; }

    }
}
