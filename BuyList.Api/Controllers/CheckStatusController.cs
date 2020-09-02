using Microsoft.AspNetCore.Mvc;

namespace BuyList.Api.Controllers
{
    [ApiController]
    [Route("v1/checkstatus")]
    public class CheckStatusController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "running" });
        }
    }
}
