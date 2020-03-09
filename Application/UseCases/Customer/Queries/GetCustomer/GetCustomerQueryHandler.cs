using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Domain.Models;

using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDto>
    {
        private readonly dbContext _context;

        public GetCustomerQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetCustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Customer.FirstOrDefaultAsync(e => e.id == request.Id);

            return new GetCustomerDto
            {
                Success = true,
                Message = "Customerw successfully retrieved",
                Data = new CustomerD
                {
                    fullname = result.fullname,
                    username = result.username,
                }
            };

        }
    }
}