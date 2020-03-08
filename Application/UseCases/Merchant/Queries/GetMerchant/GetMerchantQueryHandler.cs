using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDto>
    {
        private readonly dbContext _context;

        public GetMerchantQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetMerchantDto> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Merchants.FirstOrDefaultAsync(e => e.Id == request.Id);

            return new GetMerchantDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = new MerchantData
                {
                    name = result.name,
                    address = result.address,
                }
            };

        }
    }
}