using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IPatientRepository : IAsyncRepository<Patient>, IRepository<Patient>
    {
    }
    
}
