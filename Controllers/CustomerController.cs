using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using ValidationWithMediatr_task.Models;

namespace ValidationWithMediatr_task.Controllers
{
        public class CustomersController : ControllerBase
    {
        [ApiController]
        [Route("customer")]
        [Authorize]
        public class CustomerController : ControllerBase
        {
            private readonly dbContext _context;
            public CustomerController(dbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult GetCustomer()
            {
                var cu = _context.Customer;
                return Ok(new {message = "success retrieve data", status = true, data = cu});
            }

            [HttpPost]
            public IActionResult PostCustomer(Customer customer)
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return Ok(new {success = true, customer});
            }

            [HttpGet("{id}")]
            public IActionResult GetCustomerById(int id)
            {
                var customer = _context.Customer.First(i => i.id == id);
                return Ok(new {success = true, customer});
            }

            [HttpPut("{id}")]
            public IActionResult UpdateCustomer(int id)
            {
                var customer = _context.Customer.First(i => i.id == id);
                customer.fullname = "Na Dul Set";
                _context.SaveChanges();
                return Ok(customer);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteCustomer(int id)
            {
                var customer = _context.Customer.First(i => i.id == id);
                _context.Customer.Remove(customer);
                _context.SaveChanges();
                return Ok(customer);
            }

                
        }

    }
}