﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public string UserMail { get; set; }

        public string UserFeedback { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
