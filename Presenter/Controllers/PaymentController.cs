  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayment;
using ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayments;
using ValidationWithMediatr_task.Application.UseCases.Payment.Command.CreatePayment;
using ValidationWithMediatr_task.Infrastructure.Presistence;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediatr;
        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());

        public PaymentController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<GetPaymentDto>> GetCustomer()
        {
            return Ok(await Mediator.Send(new GetPaymentQuery(){})  );
        }

        [HttpPost]
        public async Task<ActionResult<GetPaymentQuery>> PostCustomer([FromBody] CreatePaymentCommand payload)
        {
            return Ok(await Mediator.Send(payload)) ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPaymentsDto>> GetCustomerById(int id)
        {
            return Ok(await Mediator.Send(new GetPaymentsQuery(){id = id})  );
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<GetPaymentDto>> Put(int id, [FromBody] string value)
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