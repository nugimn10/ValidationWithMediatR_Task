using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Models.Query;
using System.Collections.Generic;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsDto : BaseDto
    {
        public IList<MerchantD> Data { get; set; }
    }
}