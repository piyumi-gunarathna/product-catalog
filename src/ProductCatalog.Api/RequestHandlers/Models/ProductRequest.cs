using System;
using ProductCatalog.Domain;

namespace ProductCatalog.Api.RequestHandlers.Models
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

    }
    
}


