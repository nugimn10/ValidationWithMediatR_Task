using FluentValidation;
using ValidationWithMediatr_task.Application.UseCases.Payment.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentValidator : AbstractValidator<GetPaymentQuery>
    {
        public GetPaymentValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}