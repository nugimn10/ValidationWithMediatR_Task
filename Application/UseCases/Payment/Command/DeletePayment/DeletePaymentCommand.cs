using MediatR;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Command.DeletePayment
{
    public class DeletePaymentCommand : IRequest<DeletePaymentCommandDto>
    {
        public int id { get; set; }

        public DeletePaymentCommand(int Id)
        {
            id = Id;
        }
    }
}