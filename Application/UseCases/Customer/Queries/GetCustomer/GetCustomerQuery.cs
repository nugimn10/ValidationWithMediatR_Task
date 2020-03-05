using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQuery: IRequest<GetCustomerDto>
    {
        public int id { get; set; }
    }
}