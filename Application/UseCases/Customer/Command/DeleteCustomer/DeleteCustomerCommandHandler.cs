using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandDto>
    {
        private readonly dbContext _context;

        public DeleteCustomerCommandHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<DeleteCustomerCommandDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.Customer.FindAsync(request.id);

            if (delete == null)
            {
                return new DeleteCustomerCommandDto
                {
                    Success = false,
                    Message = "Not Found"
                };
            }

            else
            { 
                _context.Customer.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteCustomerCommandDto
                {
                    Success = true,
                    Message = "Successfully retrieved customer"
                };

            }
           
        }
    }
}