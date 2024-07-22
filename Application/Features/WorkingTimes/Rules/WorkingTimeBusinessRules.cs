using Application.Features.WorkingTimes.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

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
