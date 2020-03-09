using System;
using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Application.Models.Query;
using ValidationWithMediatr_task.Domain.Models;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Command.PutMerchant
{
    public class PutMerchantCommandHandler: IRequestHandler<PutMerchantCOmmand, PutMerchantCommandDto>
    {
        private readonly dbContext _context;
        public PutMerchantCommandHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<PutMerchantCommandDto> Handle(PutMerchantCOmmand request, CancellationToken cancellationToken)
        {
            var merchant = _context.Merchants.Find(request.DataD.Attributes.id);

            merchant.name = request.DataD.Attributes.name;
            merchant.address = request.DataD.Attributes.address;
            merchant.image = request.DataD.Attributes.image;
            merchant.rating = request.DataD.Attributes.rating;
            merchant.updated_at = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);


            await _context.SaveChangesAsync(cancellationToken);

            return new PutMerchantCommandDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}