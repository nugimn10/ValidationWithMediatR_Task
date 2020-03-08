using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Models.Query;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentDto : BaseDto
    {
        public Customer_Payment_Card Data { get; set; }
    }
}