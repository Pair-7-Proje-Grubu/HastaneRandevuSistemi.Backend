using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IClinicRepository : IAsyncRepository<Clinic>, IRepository<Clinic>
    {
    }
    
}
