using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Application.UseCases.Payment.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, GetPaymentDto>
    {
        private readonly dbContext _context;

        public GetPaymentQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetPaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Customer_Payment_Cards.FirstOrDefaultAsync(e => e.id == request.id);

            return new GetPaymentDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = new PaymentData
                {
                    customer_id = result.customer_id,
                    credit_card_number = result.credit_card_number,
                }
            };

        }
    }
}