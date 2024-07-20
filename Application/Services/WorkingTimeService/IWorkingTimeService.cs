using Domain.Entities;

namespace Application.Services.WorkingTimeService
{
    public interface IWorkingTimeService
    {
        Task<WorkingTime> GetLatestAsync();
    }
}
