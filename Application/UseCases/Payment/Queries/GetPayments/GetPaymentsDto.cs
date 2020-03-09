using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Models.Query;
using System.Collections.Generic;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsDto : BaseDto
    {
        public IList<Customer_Payment_Card> Data { get; set; }
    }
}