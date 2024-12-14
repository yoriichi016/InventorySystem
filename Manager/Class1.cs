using InventoryManagementSystem.Models;

namespace Manager
{
    public class Manager
    {
        private readonly List<Product> products = new();
        private readonly List<Supplier> suppliers = new();

        // Product Operations
        public void AddProduct(Product product) => products.Add(product);

        public void UpdateProduct(int productId, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                product.ProductName = updatedProduct.ProductName;
                product.Category = updatedProduct.Category;
                product.Quantity = updatedProduct.Quantity;
                product.Price = updatedProduct.Price;
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null) products.Remove(product);
        }

        public List<Product> GetAllProducts() => new(products);

        public Product GetProductById(int productId) => products.FirstOrDefault(p => p.ProductID == productId);

        // Supplier Operations
        public void AddSupplier(Supplier supplier) => suppliers.Add(supplier);

        public void UpdateSupplier(int supplierId, Supplier updatedSupplier)
        {
            var supplier = suppliers.FirstOrDefault(s => s.SupplierID == supplierId);
            if (supplier != null)
            {
                supplier.SupplierName = updatedSupplier.SupplierName;
                supplier.ContactInfo = updatedSupplier.ContactInfo;
                supplier.Address = updatedSupplier.Address;
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            var supplier = suppliers.FirstOrDefault(s => s.SupplierID == supplierId);
            if (supplier != null) suppliers.Remove(supplier);
        }

        public List<Supplier> GetAllSuppliers() => new(suppliers);

        public Supplier GetSupplierById(int supplierId) => suppliers.FirstOrDefault(s => s.SupplierID == supplierId);
    }
}

