using FluentValidation;
using ValidationWithMediatr_task.Application.UseCases.Payment.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductValidator()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}