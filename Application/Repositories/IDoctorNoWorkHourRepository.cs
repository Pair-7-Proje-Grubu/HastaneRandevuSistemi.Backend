using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IDoctorNoWorkHourRepository : IAsyncRepository<DoctorNoWorkHour>, IRepository<DoctorNoWorkHour>
    {
    }
}
