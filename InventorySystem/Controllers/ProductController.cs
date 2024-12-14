using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public ProductController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProducts() => Ok(_context.Products.ToList());

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductID }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var existingProduct = _context.Products.Find(id);
            if (existingProduct == null) return NotFound();

            existingProduct.ProductName = product.ProductName;
            existingProduct.Category = product.Category;
            existingProduct.Quantity = product.Quantity;
            existingProduct.Price = product.Price;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
