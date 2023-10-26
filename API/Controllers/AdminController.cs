using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        public IActionResult RegisterEmployee()
        {
            return Ok();
        }
        public IActionResult EditEmployee()
        {
            return BadRequest();
        }
        public IActionResult DeleteEmployee()
        {
            return Ok();
        }
        public IActionResult GetAll()
        {
            return Ok();
        }

        public IActionResult EditLeave()
        {
            return BadRequest();
        }
    }
}
