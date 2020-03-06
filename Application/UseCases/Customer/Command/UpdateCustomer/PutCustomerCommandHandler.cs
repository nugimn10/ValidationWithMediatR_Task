using System;
using System.Threading;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Infrastructure.Persistences;
using ValidationWithMediatr_task.Application.Models.Query;
using ValidationWithMediatr_task.Domain.Entities;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.UpdateCustomer
{
    public class PutCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandDto>
    {
        private readonly EcommerceContext _context;
        public PutCustomerCommandHandler(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<UpdateCustomerCommandDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customers = _context.CustomersData.Find(request.Data.id);

            customers.full_name = request.Data.full_name;
            customers.username = request.Data.username;
            customers.birthdate = request.Data.birthdate;
            customers.password = request.Data.password;
            customers.gender = request.Data.gender;
            customers.email = request.Data.email;
            customers.phone_number = request.Data.phone_number;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            customers.updated_at = (long)time;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateCustomerCommandDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}