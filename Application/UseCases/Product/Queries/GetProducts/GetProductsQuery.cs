using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsQuery: IRequest<GetProductsDto>
    {
        public int Id { get; set; }

        public GetProductsQuery (int id)
        {
            id =Id;
        }
    }
}