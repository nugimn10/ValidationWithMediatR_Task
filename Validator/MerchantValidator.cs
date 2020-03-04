using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ValidationWithMediatr_task.Models;

namespace ValidationWithMediatr_task.Validator
{
    public class MerchantValidator : AbstractValidator<Merchant>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("name Cant Be Empty");
            RuleFor(x => x.address).NotEmpty().WithMessage("address Cant Be Empty");
            RuleFor(x => x.rating).InclusiveBetween(1,5).WithMessage("price Cant Be Empty");
        }
    }
}