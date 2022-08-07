using ProductCatalog.Domain;

namespace ProductCatalog.Infrastructure.Data
{
    internal class ProductDbModel
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal decimal Price { get; set; }
        internal int CategoryId { get; set; }
        internal Category Category { get; set; }
    }
}

