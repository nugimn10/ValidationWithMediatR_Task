using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQuery: IRequest<GetCustomerDto>
    {
        public int Id { get; set; }
        public GetCustomerQuery(int id)
        {
            Id = id;
        }
    }
}