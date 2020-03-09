using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommandValidator : AbstractValidator<CreateMerchantCommand>
    {
        public CreateMerchantCommandValidator()
        {
            RuleFor(x => x.Data.name).NotEmpty().WithMessage("name Cant Be Empty");
            RuleFor(x => x.Data.address).NotEmpty().WithMessage("address Cant Be Empty");
            RuleFor(x => x.Data.rating).InclusiveBetween(1,5).WithMessage("price Cant Be Empty");
        }
    }

}