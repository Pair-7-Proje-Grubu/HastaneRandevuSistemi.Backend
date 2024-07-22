using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IWorkingTimeRepository : IAsyncRepository<WorkingTime>, IRepository<WorkingTime>
    {
    }
}
