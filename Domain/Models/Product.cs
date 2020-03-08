using System;
namespace ValidationWithMediatr_task.Domain.Models
{  
    public class ProductD
    {
        public int id { get; set; }
        public int merchant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

        public MerchantD merchant {get; set;}
    }
}