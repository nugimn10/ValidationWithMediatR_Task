using System.Threading;
using System.Threading.Tasks;
// using ValidationWithMediatr_task.Application.Interfaces;
using ValidationWithMediatr_task.Application.UseCases.Customer.Models;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandDto>
    {
        private readonly dbContext _context;

        public CreateCustomerCommandHandler (dbContext context)
        {
            _context = context;
        }
        public async Task<CreateCustomerCommandDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var creator = new Domain.Models.Customer
            {
                fullname = request.Data.fullname,
                username = request.Data.username
            };

            _context.Customer.Add(creator);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCustomerCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}