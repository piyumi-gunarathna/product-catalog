using Xunit;

namespace ProductCatalog.Domain.Tests
{
    public class ProductTest
    {
        public ProductTest()
        {
        }

        [Fact]
        public void ProductNameShouldNotBeEmpty()
        {
            Assert.Throws<ProductCatalogException>(() => new Product(
                    "",
                    "Neclace",
                    2500,
                    1
                ));
        }

        [Fact]
        public void ProductNameShouldNotBeWhilteSpace()
        {
            Assert.Throws<ProductCatalogException>(() => new Product(
                    " ",
                    "Neclace",
                    2500,
                    1
                ));
        }

        [Fact]
        public void ProductDescriptionShouldNotBeEmpty()
        {
            Assert.Throws<ProductCatalogException>(() => new Product(
                    "Neclace",
                    "",
                    2500,
                    1
                ));
        }

        [Fact]
        public void ProductDescriptionShouldNotWhilteSpace()
        {
            Assert.Throws<ProductCatalogException>(() => new Product(
                    "Neclace",
                    " ",
                    2500,
                    1
                ));
        }

        [Fact]
        public void ProductPriceShouldBeGraterThanZero()
        {
            Assert.Throws<ProductCatalogException>(() => new Product(
                    "Neclace",
                    "Neclace with pearls ",
                    0,
                    1
                ));
        }

        [Fact]
        public void ProductObjectShouldBeCreated()
        {
            var obj = new Product(
                "Neclace",
                 "Neclace with pearls ",
                 2500,
                 1);
            Assert.NotNull(obj);

        }
    }
}
