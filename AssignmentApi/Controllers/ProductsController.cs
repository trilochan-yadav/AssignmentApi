using Microsoft.AspNetCore.Mvc;
using AssignmentApi.BLL.Interfaces;
using AssignmentApi.Models;

namespace AssignmentApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductTransformService _service;

        public ProductsController(IProductTransformService service)
        {
            _service = service;
        }

        [HttpPost("transform")]
        public IActionResult Transform([FromBody] List<Product> products)
        {
            var result = _service.Transform(products);
            return Ok(result);
        }
    }
}
