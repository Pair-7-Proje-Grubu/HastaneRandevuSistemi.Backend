using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IDoctorRepository : IAsyncRepository<Doctor>, IRepository<Doctor>
    {

    }
    
}
