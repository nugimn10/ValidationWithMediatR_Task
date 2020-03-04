using Microsoft.AspNetCore.Mvc;
using ValidationWithMediatr_task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace ValidationWithMediatr_task.Controllers
{
    [ApiController]
    [Route("merch")]
    [Authorize]
    public class MerchantController : ControllerBase
    {
        private readonly dbContext _context;
        public MerchantController(dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMerchant()
        {
            var pa = _context.Merchants;
            return Ok(new {message = "success retrieve data", status = true, data = pa});
        }

        [HttpPost]
        public IActionResult PostMerchant(Merchant merchant)
        {
            _context.Merchants.Add(merchant);
            _context.SaveChanges();
            return Ok(merchant);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pa = _context.Merchants.First(i => i.Id == id);
            return Ok(pa);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatMerchant(int id)
        {
            var pa = _context.Merchants.First(i => i.Id == id);
            pa.name = "Buruk Rupa";
            _context.SaveChanges();
            return Ok(pa);
        }

        [HttpDelete("{id}")]
        public IActionResult DelMerchant(int id)
        {
            var pa = _context.Merchants.First(i => i.Id == id);
            _context.Merchants.Remove(pa);
            _context.SaveChanges();
            return Ok(pa);
        }
    }
}