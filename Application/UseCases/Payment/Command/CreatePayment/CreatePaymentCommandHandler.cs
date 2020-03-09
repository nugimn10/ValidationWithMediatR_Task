using System.Threading;
using System.Threading.Tasks;
// using ValidationWithMediatr_task.Application.Interfaces;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommandDto>
    {
        private readonly dbContext _context;

        public CreatePaymentCommandHandler (dbContext context)
        {
            _context = context;
        }
        public async Task<CreatePaymentCommandDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {

            var payment = new Domain.Models.Customer_Payment_Card
            {
                customer_id = request.Data.customer_id,
                credit_card_number = request.Data.credit_card_number
            };

            _context.Customer_Payment_Cards.Add(payment);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreatePaymentCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}