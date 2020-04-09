using Core.Domain.Entities;
using Framework.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.ApplicationServices
{
    public interface IArticleServices
    {
         Task<bool> Exist(long id, CancellationToken cancellationToken=default(CancellationToken));
         Task<Article> FindAsync(long id,CancellationToken cancellationToken=default(CancellationToken));
         Task<PagedList<Article>> GetPublishedArticlesAsync(int pageNumber=1,int pageSize=int.MaxValue,CancellationToken cancellationToken = default(CancellationToken));
         Task<Result> RegisterArticlesAsync(Article article, CancellationToken cancellationToken=default(CancellationToken));
         Task<Result> PublishArticleAsync(long articleId, CancellationToken cancellationToken=default(CancellationToken));
        
    }
}
