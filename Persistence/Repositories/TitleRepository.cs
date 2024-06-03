using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class TitleRepository : EfRepositoryBase<Title, HRSDbContext>, ITitleRepository
    {
        public TitleRepository(HRSDbContext context) : base(context)
        {
        }
    }

}
