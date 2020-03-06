  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProduct;
using ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProducts;
using ValidationWithMediatr_task.Application.UseCases.Product.Command.CreateProduct;
using ValidationWithMediatr_task.Infrastructure.Presistence;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediatr;
        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());

        public ProductController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<GetProductsDto>> GetCustomer()
        {
            return Ok(await Mediator.Send(new GetProductsQuery(){})  );
        }

        [HttpPost]
        public async Task<ActionResult<GetProductQuery>> PostCustomer([FromBody] CreateProductCommand payload)
        {
            return Ok(await Mediator.Send(payload)) ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDto>> GetCustomerById(int id)
        {
            return Ok(await Mediator.Send(new GetProductQuery(){id = id})  );
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Getprod>> Put(int id, [FromBody] string value)
        // {
        //     return Ok();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetPaymentDto>> Delete([FromBody] CreatePaymentCommand payload)
        // {
        //     return Ok();
        // }
    }
}