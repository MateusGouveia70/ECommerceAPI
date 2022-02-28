using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
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
        public IActionResult AddCategory()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory() 
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCategory()
        {
            return Ok();
        }
    }
}
