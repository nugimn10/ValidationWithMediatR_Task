using FluentValidation;


namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerQuery>
    {
        public GetCustomerValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}