using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Command.DeleteProduct
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandDto>
    {
        private readonly dbContext _context;

        public DeletePaymentCommandHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<DeleteProductCommandDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.Product.FindAsync(request.id);

            if (delete == null)
            {
                return new DeleteProductCommandDto
                {
                    Success = false,
                    Message = "Not Found"
                };
            }

            else
            { 
                _context.Product.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteProductCommandDto
                {
                    Success = true,
                    Message = "Successfully retrieved customer"
                };

            }
           
        }
    }
}