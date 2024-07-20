using Application.Features.Clinics.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Rules
{
    public class ClinicBusinessRules : BaseBusinessRules
    {
        public Task ClinicShouldExistWhenSelected(Clinic clinic)
        {
            if (clinic is null)
                throw new BusinessException(ClinicsMessages.ClinicNotFound);

            return Task.CompletedTask;
        }

        public Task AppointmentDurationShouldBePositiveWhenSelected(int duration)
        {
            if (duration <= 0)
                throw new BusinessException(ClinicsMessages.AppointmentTimeCannotBeZeroOrNegative);

            return Task.CompletedTask;
        }

    }
}
