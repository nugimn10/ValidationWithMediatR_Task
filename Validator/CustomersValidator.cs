using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ValidationWithMediatr_task.Models;

namespace ValidationWithMediatr_task.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.username).NotEmpty().WithMessage("Username Cant Be Empty");
            RuleFor(x => x.username).MaximumLength(20).WithMessage("Max username length");
            RuleFor(x => x.email).NotEmpty().WithMessage("Email Cant Be Empty");
            RuleFor(x => x.email).EmailAddress().WithMessage("Email is not valid email address");
            RuleFor(x => x.gender).IsInEnum<Customer, Gender>().WithMessage("gender is one of male or female");
            RuleFor(x => x.gender).NotEmpty().WithMessage("gender cant be empty");
            RuleFor(x => x.birthdate).NotEmpty().WithMessage("birthday cant be empty");
            RuleFor(x => DateTime.Now.Year - x.birthdate.Year).GreaterThanOrEqualTo(18).WithMessage("age must be greater than 18");
        }
    }


}