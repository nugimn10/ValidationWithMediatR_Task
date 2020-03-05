using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Application.UseCases.Customer.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCreatorQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
        private readonly dbContext _context;

        public GetCreatorQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetCustomersDto> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.Customer.ToListAsync();

            var result = data.Select(e => new CustomerData
            {
                fullname = e.fullname,
                username = e.username,
            });

            return new GetCustomersDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = result.ToList()
            };

        }
    }
}