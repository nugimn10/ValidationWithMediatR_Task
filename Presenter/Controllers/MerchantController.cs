using Microsoft.AspNetCore.Mvc;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("merch")]
    // [Authorize]
    public class MerchantController : ControllerBase
    {
        private readonly dbContext _context;
        public MerchantController(dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var merchant = _context.Merchants;

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = merchant
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var merchant = _context.Merchants.First(i => i.Id == id);

            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = merchant
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var merchant = _context.Merchants.First(i => i.Id == id);

            _context.Merchants.Remove(merchant);
            _context.SaveChanges();
            return Ok(merchant);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RequestData<Merchant> merput)
        {
            var mer = _context.Merchants.First(i => i.Id == id);

            mer.name = merput.data.attributes.name;
            mer.image = merput.data.attributes.image;
            mer.address = merput.data.attributes.address;
            mer.rating = merput.data.attributes.rating;
            mer.created_at = merput.data.attributes.created_at;
            mer.update_at = DateTime.Now;

            _context.Merchants.Update(mer);
            _context.SaveChanges();
            return Ok(mer);
        }

        [HttpPost]
        public IActionResult Post(RequestData<Merchant> merchant)
        {
            _context.Merchants.Add(merchant.data.attributes);
            _context.SaveChanges();
            return Ok(new
            {
                message = "success retrieve data",
                status = true,
                data = merchant
            });
        }
    }
}