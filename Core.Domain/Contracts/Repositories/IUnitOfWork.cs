using Core.Domain.Contracts.Repositories;
using Core.Domain.Contracts.Repositoriess;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IArticleRepository ArticleRepository { get; }
       
        //================================

        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
       
    }
}
