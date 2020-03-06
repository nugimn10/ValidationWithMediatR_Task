using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsQuery: IRequest<GetProductsDto>
    {
        public int id { get; set; }
    }
}