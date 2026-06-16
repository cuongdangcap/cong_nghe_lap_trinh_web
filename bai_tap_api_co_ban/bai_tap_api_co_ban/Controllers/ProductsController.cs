using Microsoft.AspNetCore.Mvc;
using bai_tap_api_co_ban.Models;

namespace bai_tap_api_co_ban.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        // POST: api/products
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.Id = products.Count + 1;
            products.Add(product);

            return Ok(product);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id phải là số nguyên dương");
            }

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Không tìm thấy sản phẩm");
            }

            return Ok(product);
        }
    }
}