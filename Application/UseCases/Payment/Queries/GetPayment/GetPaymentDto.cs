using ValidationWithMediatr_task.Application.UseCases.Payment.Models;
using ValidationWithMediatr_task.Application.Models.Query;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentDto : BaseDto
    {
        public PaymentData Data { get; set; }
    }
}