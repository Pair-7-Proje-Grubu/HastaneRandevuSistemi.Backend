using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IFeedbackRepository : IAsyncRepository<Feedback>, IRepository<Feedback>
    {
    }
}
