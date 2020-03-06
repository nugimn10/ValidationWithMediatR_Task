using FluentValidation;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsValidation : AbstractValidator<GetPaymentsQuery>
    {
        public GetPaymentsValidation()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}