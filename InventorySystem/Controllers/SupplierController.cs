using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public SupplierController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers() => Ok(_context.Suppliers.ToList());

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            return supplier != null ? Ok(supplier) : NotFound();
        }

        [HttpPost]
        public IActionResult AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSupplierById), new { id = supplier.SupplierID }, supplier);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, Supplier supplier)
        {
            var existingSupplier = _context.Suppliers.Find(id);
            if (existingSupplier == null) return NotFound();

            existingSupplier.SupplierName = supplier.SupplierName;
            existingSupplier.ContactInfo = supplier.ContactInfo;
            existingSupplier.Address = supplier.Address;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null) return NotFound();

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
