using System.Threading;
using System.Threading.Tasks;
// using ValidationWithMediatr_task.Application.Interfaces;
using ValidationWithMediatr_task.Application.UseCases.Customer.Models;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandDto>
    {
        private readonly dbContext _context;

        public CreateProductCommandHandler (dbContext context)
        {
            _context = context;
        }
        public async Task<CreateProductCommandDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var product = new Domain.Models.Product
            {
                name = request.Data.name,
                price = request.Data.price
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}