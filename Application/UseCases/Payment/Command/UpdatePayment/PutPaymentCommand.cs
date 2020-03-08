using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Models.Query;
using System;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Command.PutPayment
{
    public class PutPaymentCommand : RequestData<Customer_Payment_Card>,IRequest<PutPaymentCommandDto>
    {


    }

}