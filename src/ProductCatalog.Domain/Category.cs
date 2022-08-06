namespace ProductCatalog.Domain
{
    public class Category
    {
        public Category(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ProductCatalogException("Name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ProductCatalogException("Description cannot be null or empty.");
            }

            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

    }
}
