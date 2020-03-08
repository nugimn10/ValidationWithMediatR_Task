  
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
using ValidationWithMediatr_task.Application.UseCases.Merchant.Command.DeleteMerchant;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Command.PutMerchant;
using ValidationWithMediatr_task.Infrastructure.Presistence;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("merchant")]
    public class MerchantController : ControllerBase
    {
        private IMediator _mediatr;

        public MerchantController(IMediator Mediator)
        {
            _mediatr = Mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetMerchantsQuery>> GetCustomer()
        {
            var result = new GetMerchantsDto();
            return Ok(await _mediatr.Send(result));
        }

        [HttpPost]
        public async Task<ActionResult> PostCustomer( CreateMerchantCommand payload)
        {
            var result = await _mediatr.Send(payload);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMerchantDto>> GetCustomerById(int id)
        {
            var result = new GetMerchantQuery(id);
            return Ok(await _mediatr.Send(result));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int ID, PutMerchantCOmmand data)
        {
            data.DataD.Attributes.Id = ID;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMerchantCommand(id);
            var result = await _mediatr.Send(command);

            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });

        }
    }
}