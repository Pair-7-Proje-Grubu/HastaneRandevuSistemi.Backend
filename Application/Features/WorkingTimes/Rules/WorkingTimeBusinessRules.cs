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
        private readonly IWorkingTimeRepository _workingTimeRepository;

        public WorkingTimeBusinessRules(IWorkingTimeRepository workingTimeRepository)
        {
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task MostRecentWorkingTimeShouldExistWhenSelected()
        {
            WorkingTime? workingTime = await _workingTimeRepository.GetMostRecentAsync(true);
            if (workingTime is null)
                throw new BusinessException("Mesai saati bulunamadı!");
        }
    }
}
