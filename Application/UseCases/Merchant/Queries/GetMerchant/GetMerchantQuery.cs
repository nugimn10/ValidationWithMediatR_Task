using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQuery: IRequest<GetMerchantDto>
    {
        public int Id { get; set; }

        public GetMerchantQuery(int id)
        {
            Id = id;
        }
    }
}
