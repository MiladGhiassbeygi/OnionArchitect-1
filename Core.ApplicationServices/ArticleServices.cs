using Core.Domain.Contracts.ApplicationServices;
using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Framework.Core.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace Core.ApplicationServices
{
    public class ArticleServices : IArticleServices
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Article> FindAsync(long id, CancellationToken cancellationToken=default(CancellationToken))
        {
 
            Article article= await unitOfWork.ArticleRepository.GetByIdAsync(cancellationToken,id);
            return article;
        }
        public async Task<PagedList<Article>> GetPublishedArticlesAsync(int pageNumber = 1, int pageSize = int.MaxValue,CancellationToken cancellationToken= default(CancellationToken))
        {
            PagedList<Article> articles = await unitOfWork.ArticleRepository.GetByConditionAsync(a=>a.Published==true,pageNumber,pageSize, cancellationToken);
            return articles;
        }
        public async Task<Result> RegisterArticlesAsync(Article article, CancellationToken cancellationToken=default(CancellationToken))
        {
            await unitOfWork.ArticleRepository.AddAsync(article,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
        public async Task<Result> PublishArticleAsync(long articleId, CancellationToken cancellationToken=default(CancellationToken))
        {
            if (articleId == default(long))
                return Result.Fail<Article>("شناسه مقاله نامعتبر است");
            Article article =await unitOfWork.ArticleRepository.GetByIdAsync(cancellationToken,articleId);
            article.Published = true;
            unitOfWork.ArticleRepository.Update(article);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<bool> ExistAsync(long id, CancellationToken cancellationToken=default(CancellationToken))
        {
            return await unitOfWork.ArticleRepository.ExistAsync(cancellationToken, id);
        }
    }
}
