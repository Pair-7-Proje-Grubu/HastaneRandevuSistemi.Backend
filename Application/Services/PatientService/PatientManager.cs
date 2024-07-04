﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PatientService
{
    public static class PatientManager
    {
        public static string ConvertToString(this BloodType? bloodType)
        {
            if(bloodType == null)
            {
                return "";
            }
            return Enum.GetName(bloodType.GetType(), bloodType).Replace("Positive", "+").Replace("Negative", "-").Replace("Zero", "0");
        }
    }
}