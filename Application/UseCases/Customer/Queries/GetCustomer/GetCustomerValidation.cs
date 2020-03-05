using FluentValidation;
using ValidationWithMediatr_task.Application.UseCases.Customer.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerQuery>
    {
        public GetCustomerValidator()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}