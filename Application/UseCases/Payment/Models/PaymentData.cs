using System;
using ValidationWithMediatr_task.Domain.Models;
namespace ValidationWithMediatr_task.Application.UseCases.Payment.Models
{  
    public class PaymentData
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