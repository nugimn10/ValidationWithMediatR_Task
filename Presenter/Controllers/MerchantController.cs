  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Queries.GetMerchant;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Queries.GetMerchants;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Command.CreateMerchant;
using ValidationWithMediatr_task.Infrastructure.Presistence;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("merchant")]
    public class MerchantController : ControllerBase
    {
        private IMediator _mediatr;
        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());

        public MerchantController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<GetMerchantDto>> GetCustomer()
        {
            return Ok(await Mediator.Send(new GetMerchantQuery(){})  );
        }

        [HttpPost]
        public async Task<ActionResult<GetMerchantQuery>> PostCustomer([FromBody] CreateMerchantCommand payload)
        {
            return Ok(await Mediator.Send(payload)) ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMerchantsDto>> GetCustomerById(int id)
        {
            return Ok(await Mediator.Send(new GetMerchantsQuery(){id = id})  );
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<GetMerchantDto>> Put(int id, [FromBody] string value)
        // {
        //     return Ok();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetMerchantDto>> Delete([FromBody] CreateMerchantCommand payload)
        // {
        //     return Ok();
        // }
    }
}