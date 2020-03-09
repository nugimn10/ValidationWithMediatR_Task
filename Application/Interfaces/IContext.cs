using System;
using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ValidationWithMediatr_task.Application.Interfaces
{
    public class IContext : DbContext
    {


        public IContext(DbContextOptions<IContext> options) : base(options) { }

        public DbSet<CustomerD> Customer { get; set; }
        public DbSet<ProductD> Product { get; set; }
        public DbSet<Customer_Payment_Card> Customer_Payment_Cards {get; set;}
        public DbSet<MerchantD> Merchants {get; set;}
    
    }
}