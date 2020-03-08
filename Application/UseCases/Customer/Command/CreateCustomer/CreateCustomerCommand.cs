using MediatR;
using System;
using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Models.Query;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : RequestData<CustomerD>,IRequest<CreateCustomerCommandDto>
    {
       
    }


}