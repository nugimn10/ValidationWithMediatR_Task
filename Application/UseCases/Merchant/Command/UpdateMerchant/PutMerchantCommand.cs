using ValidationWithMediatr_task.Domain.Models;
using System;
using ValidationWithMediatr_task.Application.Models.Query;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Command.PutMerchant
{
    public class PutMerchantCOmmand : RequestData<MerchantD>,IRequest<PutMerchantCommandDto>
    {

    }

}