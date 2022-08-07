using System;
using System.Linq;

namespace ProductCatalog.Domain
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(string name, string description, decimal price, int categoryId)
        {
            var productId = _productRepository.GetByName(name);
            if(productId > 0)
            {
                throw new ProductCatalogException("Product already exist.");
            }

            var product = new Product(
                    name,
                    description,
                    price,
                    categoryId
                );

            _productRepository.Create(product);
            return product;
        }
    }
}

