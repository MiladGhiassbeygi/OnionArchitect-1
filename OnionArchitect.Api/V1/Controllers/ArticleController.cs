
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.Contracts.ApplicationServices;
using Core.Domain.Entities;
using Framework.Core.Helpers;
using Framework.Web.Api;
using Framework.Web.Filters;
using Framework.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace OnionArchitect.Api.V1.Controllers
{
    
    public class ArticleController :BaseController
    {
        private readonly PagingMetadataHelper pagingMetadataHelper;
        private readonly IArticleServices articleServices;
        private readonly IMapper mapper;

        public ArticleController(PagingMetadataHelper pagingMetadataHelper,IArticleServices articleServices, IMapper mapper)
            : base(pagingMetadataHelper)
        {
            this.pagingMetadataHelper = pagingMetadataHelper;
            this.articleServices = articleServices;
            this.mapper = mapper;
        }

        [LogRequest]
        [HttpGet(Name=nameof(GetArticles))]
        public async Task<IActionResult> GetArticles([FromQuery]PaginationParameters paginationParameters,CancellationToken cancellationToken=default(CancellationToken))
        {
            PagedList<Article> articles = await articleServices.GetPublishedArticlesAsync(paginationParameters.PageNumber, paginationParameters.PageSize, cancellationToken);

            var paginationMetadata =
                this.pagingMetadataHelper.GetPagingMetadata(articles, nameof(GetArticles), paginationParameters);

            Response.Headers.Add("X-Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return Ok(articles);
        }
    }
}