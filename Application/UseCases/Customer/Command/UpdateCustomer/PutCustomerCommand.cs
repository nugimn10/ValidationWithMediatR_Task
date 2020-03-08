using ValidationWithMediatr_task.Domain.Models;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.PutCustomer
{
    public class PutCustomerCommand : IRequest<PutCustomerCommandDto>
    {
        public Customer DataD { get; set; }
    }
}