using Core.Domain.Contracts.Repositoriess;
using Core.Domain.Entities;
using Infra.Data.SqlServer.DbContexts;

namespace Infra.Data.SqlServer.Repositories
{
    public class ArticleRepository : GenericBaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(OnionArchitectDbContext dbContext) : base(dbContext)
        {

        }
    }
}
