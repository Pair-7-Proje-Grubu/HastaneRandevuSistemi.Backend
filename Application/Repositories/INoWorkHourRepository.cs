using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface INoWorkHourRepository : IAsyncRepository<NoWorkHour>, IRepository<NoWorkHour>
    {
    }
}
