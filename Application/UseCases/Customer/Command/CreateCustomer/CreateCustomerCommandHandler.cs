using System.Threading;
using System.Threading.Tasks;
// using ValidationWithMediatr_task.Application.Interfaces;
using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Interfaces;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using ValidationWithMediatr_task.Application.Models.Query;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandDto>
    {
        private readonly IContext _context;

        public CreateCustomerCommandHandler (IContext context)
        {
            _context = context;
        }
        public async Task<CreateCustomerCommandDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = new Domain.Models.CustomerD
            {
                fullname = request.DataD.Attributes.fullname,
                username = request.DataD.Attributes.username,
                birthdate = request.DataD.Attributes.birthdate,
                passowrd = request.DataD.Attributes.passowrd,
                kelamin = request.DataD.Attributes.kelamin,
                email = request.DataD.Attributes.email,
                phoneNumber = request.DataD.Attributes.phoneNumber
            };
            if (request.DataD.Attributes.kelamin == "male")
            {
                customer.gender = Gender.male;
            }
            else if (request.DataD.Attributes.kelamin == "female")
            {
                customer.gender = Gender.female;
            }

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCustomerCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}