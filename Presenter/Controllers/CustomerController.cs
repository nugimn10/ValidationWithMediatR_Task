  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer;
using ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomers;
using ValidationWithMediatr_task.Application.UseCases.Customer.Command.CreateCustomer;
using ValidationWithMediatr_task.Application.UseCases.Customer.Command.DeleteCustomer;
using ValidationWithMediatr_task.Infrastructure.Presistence;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;
        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());

        public CustomerController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersDto>> GetCustomer()
        {
            return Ok(await Mediator.Send(new GetCustomersQuery(){})  );
        }

        [HttpPost]
        public async Task<ActionResult<GetCustomerDto>> PostCustomer([FromBody] CreateCustomerCommand payload)
        {
            return Ok(await Mediator.Send(payload)) ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerDto>> GetCustomerById(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerQuery(){id = id})  );
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<GetCustomerDto>> Put(int id, [FromBody] string value)
        // {
        //     return Ok();
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await _mediatr.Send(command);

            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });

        }
    }
}