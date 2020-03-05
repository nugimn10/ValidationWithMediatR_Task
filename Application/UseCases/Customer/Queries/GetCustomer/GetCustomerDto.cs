using ValidationWithMediatr_task.Application.UseCases.Customer.Models;
using ValidationWithMediatr_task.Application.Models.Query;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerDto : BaseDto
    {
        public CustomerData Data { get; set; }
    }
}