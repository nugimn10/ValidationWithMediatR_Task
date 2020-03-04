
using System;
using Microsoft.EntityFrameworkCore;

namespace ValidationWithMediatr_task.Models
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer_Payment_Card> Customer_Payment_Cards {get; set;}
        public DbSet<Merchant> Merchants {get; set;}

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Customer_Payment_Card>()
            .HasOne(a => a.customer).WithMany().HasForeignKey(a => a.customer_id);
            modelBuilder
            .Entity<Product>()
            .HasOne(a => a.merchant).WithMany().HasForeignKey(a => a.merchant_id);
        }

    }
}