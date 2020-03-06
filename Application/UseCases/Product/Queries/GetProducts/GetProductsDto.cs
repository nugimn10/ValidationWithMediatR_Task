using ValidationWithMediatr_task.Application.UseCases.Product.Models;
using ValidationWithMediatr_task.Application.Models.Query;
using System.Collections.Generic;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsDto : BaseDto
    {
        public IList<ProductData> Data { get; set; }
    }
}