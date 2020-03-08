using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsDto>
    {
        private readonly dbContext _context;

        public GetProductsQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetProductsDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.Product.ToListAsync();

            var result = data.Select(e => new ProductD
            {
                name = e.name,
                price = e.price,
            });

            return new GetProductsDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = result.ToList()
            };

        }
    }
}