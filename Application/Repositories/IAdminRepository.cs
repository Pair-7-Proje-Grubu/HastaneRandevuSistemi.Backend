using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IAdminRepository : IAsyncRepository<Admin>, IRepository<Admin>
    {
    }
    
}
