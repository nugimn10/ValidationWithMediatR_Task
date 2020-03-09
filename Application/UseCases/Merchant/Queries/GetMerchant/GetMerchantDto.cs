using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Models.Query;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantDto : BaseDto
    {
        public MerchantD Data { get; set; }
    }
}