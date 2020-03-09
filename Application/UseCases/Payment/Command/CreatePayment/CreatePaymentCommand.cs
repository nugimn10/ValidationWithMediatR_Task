using MediatR;
using System;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommand : IRequest<CreatePaymentCommandDto>
    {
        public CreatePaymentData Data { get; set; }
    }

    public class CreatePaymentData
    {
        public int customer_id { get; set; }
        public string name_no_card { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public int postal_code { get; set; }
        public string credit_card_number { get; set; }
        public CustomerD customer {get; set;}

    }

}