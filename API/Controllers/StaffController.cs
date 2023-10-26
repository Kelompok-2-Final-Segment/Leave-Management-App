using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        [HttpPost]
        public IActionResult RequestLeave()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteRequest()
        {
            return Ok();
        }
    }
}
