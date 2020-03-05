using MediatR;
using System;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Command.CreateCreator
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandDto>
    {
        public CreateCustomerData Data { get; set; }
    }

    public class CreateCustomerData
    {

        public string fullname { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string passowrd { get; set; }
        public Gender gender { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}