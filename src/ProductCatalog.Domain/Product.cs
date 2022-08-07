namespace ProductCatalog.Domain
{
    public class Product
    {
        public Product(string name, string description, decimal price, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ProductCatalogException("Name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ProductCatalogException("Description cannot be null or empty.");
            }
            if (price <= 0)
            {
                throw new ProductCatalogException("Price should be greater than 0");
            }
            if (categoryId <= 0 )
            {
                throw new ProductCatalogException("Category id has to positive");
            }

            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }
    }
}
