using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Models;
using System.Collections.Generic;

namespace InventoryManagementSystem.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
