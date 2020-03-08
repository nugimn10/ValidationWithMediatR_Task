using MediatR;
using System;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommand : IRequest<CreateMerchantCommandDto>
    {
        public MerchantD Data { get; set; }
    }

    public class CreateMerchantData
    {

        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
    }
}