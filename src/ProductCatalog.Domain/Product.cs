namespace ProductCatalog.Domain
{
    public class Product
    {
        public Product(string name, string description, decimal price, Category category)
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
            if (category == null)
            {
                throw new ProductCatalogException("Category cannot be null.");
            }

            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; private set; }
    }
}
