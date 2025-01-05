using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneLibrary.Interfaces;
using PhoneLibrary.Models;

namespace PhoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductInterface productService;
        public ProductController(ILogger<ProductController> logger, IProductInterface productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(bool featured)
        {
            var product = await productService.GetProductList(featured);
            return Ok(product);
        }

        [HttpPost]
        [Route("CreateProducts")]
        public async Task<IActionResult> CreateProducts([FromBody]Product model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new MyResponse { Code = 400, Message="all fields are required" });
            }

            var product = await productService.CreateProductRecords(model);
            return Ok(product);
        }
    }
}
