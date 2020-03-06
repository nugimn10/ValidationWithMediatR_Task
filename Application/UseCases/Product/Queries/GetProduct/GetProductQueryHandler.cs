using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Application.UseCases.Product.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProdcutQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        private readonly dbContext _context;

        public GetProdcutQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Product.FirstOrDefaultAsync(e => e.id == request.id);

            return new GetProductDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = new ProductData
                {
                    name = result.name,
                    price = result.price,
                }
            };

        }
    }
}