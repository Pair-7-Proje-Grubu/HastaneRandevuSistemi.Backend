using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class FeedbackRepository : EfRepositoryBase<Feedback, HRSDbContext>, IFeedbackRepository
    {
        public FeedbackRepository(HRSDbContext context) : base(context)
        {
        }
    }
}
