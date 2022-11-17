using Microsoft.EntityFrameworkCore;
using MyMiniProject.DataLayer.AppDbContext;
using MyMiniProject.DataLayer.MyAppDbContext;
using MyMiniProject.Entities;
using MyMiniProject.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniProject.Services.EFServices
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        private readonly IUnitOfWork _db;
        private readonly DbSet<Customer> _customer;
        public CustomerService(IUnitOfWork db) : base(db)
        {
            _db = db;
            this._customer = db.Set<Customer>();
        }
    }
}
