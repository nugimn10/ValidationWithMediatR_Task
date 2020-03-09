using System.Threading;
using System.Threading.Tasks;
// using ValidationWithMediatr_task.Application.Interfaces;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, CreateMerchantCommandDto>
    {
        private readonly dbContext _context;

        public CreateMerchantCommandHandler (dbContext context)
        {
            _context = context;
        }
        public async Task<CreateMerchantCommandDto> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {

            var merchant = new Domain.Models.MerchantD
            {
                name = request.Data.name,
                address = request.Data.address
            };

            _context.Merchants.Add(merchant);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateMerchantCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}