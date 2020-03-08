using System;
using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ValidationWithMediatr_task.Application.Interfaces
{
    public interface IContext
    {


        DbSet<CustomerD> Customer { get; set; }
        DbSet<ProductD> Product { get; set; }
        DbSet<Customer_Payment_Card> Customer_Payment_Cards {get; set;}
        DbSet<MerchantD> Merchants {get; set;} 

        Task<int> SaveChangesAsync(CancellationToken cancellation);
    
    }
}