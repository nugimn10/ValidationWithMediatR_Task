using Microsoft.AspNetCore.Mvc;
using ValidationWithMediatr_task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;

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
            return Ok(new 
            {
                message = "success retrieve data", 
                status = true, 
                data = cu
            });
        }

        [HttpPost]
        public IActionResult PostCustomer(RequestData<Customer> customer)
        {
            _context.Customer.Add(customer.data.attributes);
            _context.SaveChanges();
            return Ok(new 
            {
                message = "success retrieve data", 
                status = true, 
                data = customer
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customer.First(i => i.id == id);
            return Ok(new 
            {
                message = "success retrieve data", 
                status = true, 
                data = customer
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RequestData<Customer> customerput)
        {
            var customer = _context.Customer.First(i => i.id == id);

            customer.fullname = customerput.data.attributes.fullname;
            customer.username = customerput.data.attributes.username;
            customer.birthdate = customerput.data.attributes.birthdate;
            customer.passowrd = customerput.data.attributes.passowrd;
            customer.gender = customerput.data.attributes.gender;
            customer.email = customerput.data.attributes.email;
            customer.phoneNumber = customerput.data.attributes.phoneNumber;
            customer.created_at = customerput.data.attributes.created_at;
            customer.updated_at = DateTime.Now;

            _context.Customer.Update(customer);
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