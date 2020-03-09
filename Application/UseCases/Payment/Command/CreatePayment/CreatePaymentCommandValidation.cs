using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.Data.name_no_card).NotEmpty().WithMessage("Username Cant Be Empty");
            RuleFor(x => x.Data.name_no_card).MaximumLength(20).WithMessage("Max username length");
            RuleFor(x => x.Data.exp_month).NotEmpty().WithMessage("exp moth Cant Be Empty");
            RuleFor(x => Convert.ToInt32(x.Data.exp_month)).InclusiveBetween(1,12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.Data.exp_year).NotEmpty().WithMessage("exp year Cant Be Empty");
            RuleFor(x => x.Data.credit_card_number).CreditCard().WithMessage("credit card number must be type of credit card number");
        }
    }

}