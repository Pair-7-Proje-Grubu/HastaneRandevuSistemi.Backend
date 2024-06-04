﻿using Core.DataAccess;
using Core.Entities;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class DoctorRepository : EfRepositoryBase<Doctor, HRSDbContext>, IDoctorRepository
    {
        public DoctorRepository(HRSDbContext context) : base(context)
        {

        }
    }

}