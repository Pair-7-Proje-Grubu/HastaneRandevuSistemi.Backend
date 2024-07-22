using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IAllergyRepository : IAsyncRepository<Allergy>, IRepository<Allergy>
    {
    }
    
}
