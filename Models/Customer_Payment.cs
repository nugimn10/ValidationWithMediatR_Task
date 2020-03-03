using System;
namespace ValidationWithMediatr_task.Models
{  
    public class Customer_Payment_Card
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string name_no_card { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public int postal_code { get; set; }
        public string credit_card_number { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }

}