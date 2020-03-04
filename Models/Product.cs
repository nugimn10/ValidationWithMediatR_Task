using System;
namespace ValidationWithMediatr_task.Models
{  
    public class Product
    {
        public int id { get; set; }
        public int merchant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

        public Merchant merchant {get; set;}
    }
}