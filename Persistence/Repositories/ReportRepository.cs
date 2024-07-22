using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ReportRepository : EfRepositoryBase<Report, HRSDbContext>, IReportRepository
    {
        public ReportRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
