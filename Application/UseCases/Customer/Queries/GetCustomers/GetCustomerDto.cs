using ValidationWithMediatr_task.Application.UseCases.Customer.Models;
using ValidationWithMediatr_task.Application.Models.Query;
using System.Collections.Generic;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersDto : BaseDto
    {
        public IList<CustomerData> Data { get; set; }
    }
}