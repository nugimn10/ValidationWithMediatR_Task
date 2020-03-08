using FluentValidation;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomerValidator : AbstractValidator<GetCustomersQuery>
    {
        public GetCustomerValidator()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}