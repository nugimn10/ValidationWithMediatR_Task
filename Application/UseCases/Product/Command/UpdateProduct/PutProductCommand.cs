using ValidationWithMediatr_task.Domain.Models;
using System;
using ValidationWithMediatr_task.Application.Models.Query;
using MediatR;

namespace ValidationWithMediatr_task.Application.UseCases.Product.Command.PutProduct
{
    public class PutProductCommand : RequestData<ProductD>, IRequest<PutProductCommandDto>
    {

    }

}