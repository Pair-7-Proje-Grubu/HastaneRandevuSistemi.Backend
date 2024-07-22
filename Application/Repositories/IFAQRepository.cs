using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IFAQRepository : IAsyncRepository<FAQ>, IRepository<FAQ>
    {
    }
}
