using MediatR;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerCommandDto>
    {
        public int id { get; set; }

        public DeleteCustomerCommand(int Id)
        {
            id = Id;
        }
    }
}