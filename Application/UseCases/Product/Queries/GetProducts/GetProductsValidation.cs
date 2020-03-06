using FluentValidation;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetPaymentsValidation : AbstractValidator<GetProductsQuery>
    {
        public GetPaymentsValidation()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}