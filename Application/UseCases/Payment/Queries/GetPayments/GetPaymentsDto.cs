using ValidationWithMediatr_task.Application.UseCases.Payment.Models;
using ValidationWithMediatr_task.Application.Models.Query;
using System.Collections.Generic;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsDto : BaseDto
    {
        public IList<PaymentData> Data { get; set; }
    }
}