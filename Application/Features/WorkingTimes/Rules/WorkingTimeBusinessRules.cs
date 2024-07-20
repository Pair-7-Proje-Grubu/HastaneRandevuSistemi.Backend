using Application.Features.WorkingTimes.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WorkingTimes.Rules
{
    public class WorkingTimeBusinessRules : BaseBusinessRules
    {

        public WorkingTimeBusinessRules()
        {
        }

        public Task WorkingTimeShouldExistWhenSelected(WorkingTime? workingTime)
        {
            if (workingTime is null)
                throw new BusinessException(WorkingTimesMessages.WorkingTimeNotFound);

            return Task.CompletedTask;
        }
    }
}
