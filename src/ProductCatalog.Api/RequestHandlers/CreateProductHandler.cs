using ProductCatalog.Api.RequestHandlers.Models;
using ProductCatalog.Domain;

namespace ProductCatalog.Api.RequestHandlers
{
    public class CreateProductHandler
    {
        private readonly ProductService _productService;

        public CreateProductHandler(ProductService productService)
        {
            _productService = productService;
        }

        public ProductResponse Handle(ProductRequest request)
        {
            var product = _productService.CreateProduct(
                request.Name,
                request.Description,
                request.Price,
                request.CategoryId);
            return new ProductResponse();
        }
    }
}

