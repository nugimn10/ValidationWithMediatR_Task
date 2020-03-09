  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ValidationWithMediatr_task.Application.UseCases.Payment.Command.DeletePayment;
using ValidationWithMediatr_task.Application.UseCases.Payment.Command.PutPayment;
using ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayment;
using ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayments;
using ValidationWithMediatr_task.Application.UseCases.Payment.Command.CreatePayment;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using Microsoft.AspNetCore.Authorization;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("payment")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediatr;

        public PaymentController(IMediator Mediator)
        {
            _mediatr = Mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetPaymentsQuery>> GetCustomer()
        {
            var result = new GetPaymentsDto();
            return Ok(await _mediatr.Send(result));
        }

        [HttpPost]
        public async Task<ActionResult> PostCustomer( CreatePaymentCommand payload)
        {
            var result = await _mediatr.Send(payload);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPaymentDto>> GetCustomerById(int id)
        {
            var result = new GetPaymentQuery(id);
            return Ok(await _mediatr.Send(result));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int ID, PutPaymentCommand data)
        {
            data.DataD.Attributes.id = ID;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePaymentCommand(id);
            var result = await _mediatr.Send(command);

            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });

        }
    }
}