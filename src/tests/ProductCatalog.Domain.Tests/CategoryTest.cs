using Xunit;

namespace ProductCatalog.Domain.Tests
{
    public class CategoryTest
    {
        public CategoryTest()
        {
        }

        [Fact]
        public void CategoryNameShouldNotBeEmpty()
        {
            Assert.Throws<ProductCatalogException>(() => new Category(
                    "",
                    "Jewellery"
                ));
        }

        [Fact]
        public void CategoryNameShouldNotBeWhilteSpace()
        {
            Assert.Throws<ProductCatalogException>(() => new Category(
                    " ",
                    "Jewellery"
                ));
        }

        [Fact]
        public void CategoryDescriptionShouldNotBeEmpty()
        {
            Assert.Throws<ProductCatalogException>(() => new Category(
                    "Jewellery",
                    ""
                ));
        }

        [Fact]
        public void CategoryDescriptionShouldNotWhilteSpace()
        {
            Assert.Throws<ProductCatalogException>(() => new Category(
                    "Jewellery",
                    " "
                ));
        }
    }
}
