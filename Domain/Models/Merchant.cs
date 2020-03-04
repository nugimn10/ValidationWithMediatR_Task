using System;
namespace ValidationWithMediatr_task.Domain.Models
{  
    public class Merchant
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
    }
}