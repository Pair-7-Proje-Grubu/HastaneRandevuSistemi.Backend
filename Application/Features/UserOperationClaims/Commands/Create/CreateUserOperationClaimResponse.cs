﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimResponse
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
