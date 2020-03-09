using MediatR;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandDto>
    {
        public int id { get; set; }

        public DeleteProductCommand(int Id)
        {
            id = Id;
        }
    }
}