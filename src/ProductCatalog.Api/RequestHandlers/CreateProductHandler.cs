using ProductCatalog.Api.RequestHandlers.Models;
using ProductCatalog.Domain;

namespace ProductCatalog.Api.RequestHandlers
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ProductResponse Handle(ProductRequest request)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.CategoryId
                );

            _productRepository.Create(product);
            return new ProductResponse();
        }
    }
}

