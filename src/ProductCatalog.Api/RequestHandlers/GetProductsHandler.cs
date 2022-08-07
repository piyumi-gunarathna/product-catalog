using ProductCatalog.Api.RequestHandlers.Models;
using ProductCatalog.Domain;

namespace ProductCatalog.Api.RequestHandlers
{
    public class GetProductsHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<ProductResponse> Handle()
        {
            var Products = _productRepository.Get().Select(s => new ProductResponse
            {
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                CategoryId = s.CategoryId
            });
            return Products;

        }
    }
}

