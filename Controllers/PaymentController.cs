using Microsoft.AspNetCore.Mvc;
using ValidationWithMediatr_task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace ValidationWithMediatr_task.Controllers
{
    [ApiController]
    [Route("payment")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly dbContext _context;
        public PaymentController(dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPayment()
        {
            var pa = _context.Customer_Payment_Cards;
            return Ok(new {message = "success retrieve data", status = true, data = pa});
        }

        [HttpPost]
        public IActionResult PostPayment(Customer_Payment_Card payment)
        {
            _context.Customer_Payment_Cards.Add(payment);
            _context.SaveChanges();
            return Ok(payment);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var pa = _context.Customer_Payment_Cards.First(i => i.id == id);
            return Ok(pa);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id)
        {
            var pa = _context.Customer_Payment_Cards.First(i => i.id == id);
            pa.name_no_card = "Bonnana Boat";
            _context.SaveChanges();
            return Ok(pa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            var pa = _context.Customer_Payment_Cards.First(i => i.id == id);
            _context.Customer_Payment_Cards.Remove(pa);
            _context.SaveChanges();
            return Ok(pa);
        }
    }
}