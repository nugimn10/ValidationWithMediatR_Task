using ValidationWithMediatr_task.Application.UseCases.Product.Models;
using ValidationWithMediatr_task.Application.Models.Query;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductDto : BaseDto
    {
        public ProductData Data { get; set; }
    }
}