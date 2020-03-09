using ValidationWithMediatr_task.Application.Models.Query;
using ValidationWithMediatr_task.Domain.Models;
using System;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.PutCustomer
{
    public class PutCustomerCommand : RequestData<CustomerD>,IRequest<PutCustomerCommandDto>
    {

    }
}