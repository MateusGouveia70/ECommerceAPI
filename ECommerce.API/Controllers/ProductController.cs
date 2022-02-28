using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddProduct()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct()
        {
            return Ok();
        }
    }
}
