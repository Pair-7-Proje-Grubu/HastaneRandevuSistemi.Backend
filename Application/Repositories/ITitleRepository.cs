using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ITitleRepository : IAsyncRepository<Title>, IRepository<Title>
    {
    }
    
}
