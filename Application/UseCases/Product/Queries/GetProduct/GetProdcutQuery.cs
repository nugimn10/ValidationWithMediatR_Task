using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public int id { get; set; }
    }
}