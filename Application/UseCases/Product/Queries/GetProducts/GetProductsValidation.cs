using FluentValidation;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetPaymentsValidation : AbstractValidator<GetProductsQuery>
    {
        public GetPaymentsValidation()
        {

        }
    }
}