using Application.Features.WorkingTimes.Rules;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.WorkingTimeService
{
   
    public class WorkingTimeManager : IWorkingTimeService
    {
        private readonly IWorkingTimeRepository _workingTimeRepository;
        private readonly WorkingTimeBusinessRules _workingTimeBusinessRules;

        public WorkingTimeManager(IWorkingTimeRepository workingTimeRepository, WorkingTimeBusinessRules workingTimeBusinessRules)
        {
            _workingTimeRepository = workingTimeRepository;
            _workingTimeBusinessRules = workingTimeBusinessRules;
        }

        public async Task<WorkingTime> GetLatestAsync()
        {
            WorkingTime? workingTime = await _workingTimeRepository.GetAsync(orderBy: wt => wt.OrderByDescending(x => x.Id), asNoTracking: true);
            await _workingTimeBusinessRules.WorkingTimeShouldExistWhenSelected(workingTime);
            return workingTime!;
        }

    }
}
