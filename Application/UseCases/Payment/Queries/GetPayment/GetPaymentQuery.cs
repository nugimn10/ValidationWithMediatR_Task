using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentQuery : IRequest<GetPaymentDto>
    {
        public int id { get; set; }
    }
}