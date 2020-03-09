using MediatR;
using System;
using ValidationWithMediatr_task.Domain.Models;
using ValidationWithMediatr_task.Application.Models.Query;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommand : RequestData<ProductD>,IRequest<CreateProductCommandDto>
    {

    }



}