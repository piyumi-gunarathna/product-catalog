using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Api.RequestHandlers;
using ProductCatalog.Api.RequestHandlers.Models;
using ProductCatalog.Domain;

namespace ProductCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductHandler _createProductHandler;
        private readonly GetProductsHandler _getProductsHandler;


        public ProductController(
            CreateProductHandler createProductHandler,
            GetProductsHandler getProductsHandler)
        {
            _createProductHandler = createProductHandler;
            _getProductsHandler = getProductsHandler;
        }

        [HttpPost]
        public ObjectResult Post(ProductRequest request)
        {
            try
            {
                var response = _createProductHandler.Handle(request);
                return new ObjectResult(response);
            }
            catch (ProductCatalogException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                var errorResponse = new ObjectResult("Unknown error occured. Please try again or contact administrator.");
                errorResponse.StatusCode = 500;
                return errorResponse;
            }
        }

        [HttpGet]
        public ObjectResult Get()
        {
            try
            {
                var response = _getProductsHandler.Handle();
                return new ObjectResult(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ObjectResult("Unknown error occured. Please try again or contact administrator.");
                errorResponse.StatusCode = 500;
                return errorResponse;
            }
        }
    }
}
