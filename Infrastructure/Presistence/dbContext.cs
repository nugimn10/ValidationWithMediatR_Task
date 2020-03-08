
using System;
using Microsoft.EntityFrameworkCore;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Infrastructure.Presistence
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<CustomerD> Customer { get; set; }
        public DbSet<ProductD> Product { get; set; }
        public DbSet<Customer_Payment_Card> Customer_Payment_Cards {get; set;}
        public DbSet<MerchantD> Merchants {get; set;}

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Customer_Payment_Card>()
            .HasOne(a => a.customer).WithMany().HasForeignKey(a => a.customer_id);
            modelBuilder
            .Entity<ProductD>()
            .HasOne(a => a.merchant).WithMany().HasForeignKey(a => a.merchant_id);
        }

    }
}