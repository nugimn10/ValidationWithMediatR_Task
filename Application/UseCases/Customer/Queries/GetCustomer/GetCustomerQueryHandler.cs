using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Application.UseCases.Customer.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCreatorQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDto>
    {
        private readonly dbContext _context;

        public GetCreatorQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetCustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Customer.FirstOrDefaultAsync(e => e.id == request.id);

            return new GetCustomerDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = new CustomerData
                {
                    fullname = result.fullname,
                    username = result.username,
                }
            };

        }
    }
}