using Microsoft.AspNetCore.Mvc;
using ValidationWithMediatr_task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace ValidationWithMediatr_task.Controllers
{
    [ApiController]
    [Route("customer")]
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
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customer.First(i => i.id == id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _context.Customer.First(i => i.id == id);
            customer.fullname = "Bonnana Boat";
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