using System.Collections.Generic;

namespace ProductCatalog.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Create(Product product);
    }
}

