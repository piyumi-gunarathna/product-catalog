using System.Collections.Generic;
using System.Linq;
using ProductCatalog.Domain;

namespace ProductCatalog.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductCatalogDbContext _dbContext;

        public ProductRepository(ProductCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Create(Product product)
        {
            _dbContext.Database.EnsureCreated();

            var productDbModel = new ProductDbModel();
            productDbModel.Name = product.Name;
            productDbModel.Description = product.Description;
            productDbModel.Price = product.Price;
            productDbModel.CategoryId = product.CategoryId;

            _dbContext.Product.Add(productDbModel);
            _dbContext.SaveChanges();
            return product;
        }

        public IEnumerable<Product> Get()
        {
            _dbContext.Database.EnsureCreated();

            var products = _dbContext.Product
                .Where(s => s.Id > 0)
                .Select(s => new Product(
                        s.Name,
                        s.Description,
                        s.Price,
                        s.CategoryId
                    )).ToList();

            return products;
        }

        public int GetByName(string name)
        {
            _dbContext.Database.EnsureCreated();

            var productId = _dbContext.Product
                .Where(s => s.Name.ToLower().Equals(name.ToLower()))
                .Select(s => s.Id).FirstOrDefault();

            return productId;
        }
    }
}




