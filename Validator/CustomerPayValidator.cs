using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ValidationWithMediatr_task.Models;

namespace ValidationWithMediatr_task.Validator
{
    public class CustomerpayValidator : AbstractValidator<Customer_Payment_Card>
    {
        public CustomerpayValidator()
        {
            RuleFor(x => x.name_no_card).NotEmpty().WithMessage("Username Cant Be Empty");
            RuleFor(x => x.name_no_card).MaximumLength(20).WithMessage("Max username length");
            RuleFor(x => x.exp_month).NotEmpty().WithMessage("exp moth Cant Be Empty");
            RuleFor(x => Convert.ToInt32(x.exp_month)).ExclusiveBetween(1,12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.exp_year).NotEmpty().WithMessage("exp year Cant Be Empty");
            RuleFor(x => x.credit_card_number).CreditCard().WithMessage("credit card number must be type of credit card number");
            
        }
    }


}