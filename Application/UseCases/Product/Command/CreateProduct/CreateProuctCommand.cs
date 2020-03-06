using MediatR;
using System;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandDto>
    {
        public CreateProdcutData Data { get; set; }
    }

    public class CreateProdcutData
    {
        public int merchant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

    }

}