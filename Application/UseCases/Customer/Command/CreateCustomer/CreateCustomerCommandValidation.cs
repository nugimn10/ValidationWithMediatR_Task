using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.DataD.Attributes.username).NotEmpty().WithMessage("Username Cant Be Empty");
            RuleFor(x => x.DataD.Attributes.username).MaximumLength(20).WithMessage("Max username length");
            RuleFor(x => x.DataD.Attributes.email).NotEmpty().WithMessage("Email Cant Be Empty");
            RuleFor(x => x.DataD.Attributes.email).EmailAddress().WithMessage("Email is not valid email address");
            RuleFor(x => x.DataD.Attributes.gender).IsInEnum<CreateCustomerCommand, Gender>().WithMessage("gender is one of male or female");
            RuleFor(x => x.DataD.Attributes.gender).NotEmpty().WithMessage("gender cant be empty");
            RuleFor(x => x.DataD.Attributes.birthdate).NotEmpty().WithMessage("birthday cant be empty");
            RuleFor(x => DateTime.Now.Year - x.DataD.Attributes.birthdate.Year).GreaterThanOrEqualTo(18).WithMessage("age must be greater than 18");
        }
    }

}