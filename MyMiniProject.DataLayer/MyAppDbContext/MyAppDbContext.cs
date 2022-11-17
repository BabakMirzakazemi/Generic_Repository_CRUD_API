using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyMiniProject.DataLayer.MyAppDbContext;
using MyMiniProject.Entities;

namespace MyMiniProject.DataLayer.AppDbContext;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {

    }
    public DbSet<Customer> Tbl_Customers { get; set; }
    public void MarkAsDeleted<TEntity>(TEntity entity)
       => base.Entry(entity).State = EntityState.Deleted;
}
