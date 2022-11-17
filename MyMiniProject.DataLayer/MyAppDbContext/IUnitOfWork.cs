using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyMiniProject.DataLayer.MyAppDbContext
{
    public interface IUnitOfWork:IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void MarkAsDeleted<TEntity>(TEntity entity);
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
