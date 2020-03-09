using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsQuery: IRequest<GetMerchantsDto>
    {
        public int id { get; set; }

        public GetMerchantsQuery(int Id)
        {
            id = Id;
        }
    }
}