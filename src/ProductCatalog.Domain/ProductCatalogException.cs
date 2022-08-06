using System;
namespace ProductCatalog.Domain
{
    public class ProductCatalogException : Exception
    {
        public ProductCatalogException()
        {
        }

        public ProductCatalogException(string message) : base(message)
        {
        }

        public ProductCatalogException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
