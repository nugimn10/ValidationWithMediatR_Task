using Microsoft.AspNetCore.Mvc;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ValidationWithMediatr_task.Infrastructure.Presistence;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("prod")]
    public class ProductController : ControllerBase
    {
        private readonly dbContext _context;
        public ProductController(dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pa = _context.Product;
            return Ok(new {message = "success retrieve data", status = true, data = pa});
        }

        [HttpPost]
        public IActionResult PostMerchant(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pa = _context.Product.First(i => i.id == id);
            return Ok(pa);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatMerchant(int id)
        {
            var pa = _context.Product.First(i => i.id == id);
            pa.name = "Buruk Rupa";
            _context.SaveChanges();
            return Ok(pa);
        }

        [HttpDelete("{id}")]
        public IActionResult DelMerchant(int id)
        {
            var pa = _context.Product.First(i => i.id == id);
            _context.Product.Remove(pa);
            _context.SaveChanges();
            return Ok(pa);
        }
    }
}