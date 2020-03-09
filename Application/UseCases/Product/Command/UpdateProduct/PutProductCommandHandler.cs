using System;
using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Application.Interfaces;
using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Models;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Command.PutProduct
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommand, PutProductCommandDto>
    {
        private readonly IContext _context;
        public PutProductCommandHandler (IContext context)
        {
            _context = context;
        }
        public async Task<PutProductCommandDto> Handle(PutProductCommand request, CancellationToken cancellationToken)
        {
            var Product = _context.Product.Find(request.DataD.Attributes.id);

            Product.merchant_id = request.DataD.Attributes.merchant_id;
            Product.name = request.DataD.Attributes.name;
            Product.price = request.DataD.Attributes.price;
            Product.updated_at = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);


            await _context.SaveChangesAsync(cancellationToken);

            return new PutProductCommandDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}