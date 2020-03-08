using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Validator
{
    public class ProductValidator : AbstractValidator<ProductD>
    {
        public ProductValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("name Cant Be Empty");
            RuleFor(x => x.name).MaximumLength(50).WithMessage("Max username length 50");
            RuleFor(x => x.price).NotEmpty().WithMessage("price Cant Be Empty");
            RuleFor(x => x.price).GreaterThanOrEqualTo(1000).WithMessage("price must be greater than 1000");

        }
    }
}