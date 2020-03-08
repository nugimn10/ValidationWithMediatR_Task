using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Command.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, DeletePaymentCommandDto>
    {
        private readonly dbContext _context;

        public DeletePaymentCommandHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<DeletePaymentCommandDto> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.Merchants.FindAsync(request.id);

            if (delete == null)
            {
                return new DeletePaymentCommandDto
                {
                    Success = false,
                    Message = "Not Found"
                };
            }

            else
            { 
                _context.Merchants.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeletePaymentCommandDto
                {
                    Success = true,
                    Message = "Successfully retrieved customer"
                };

            }
           
        }
    }
}