using Microsoft.AspNetCore.Mvc;

namespace UnityHealth.Controllers
{
    [ApiController]
    [Route("/health")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Healthy");
        }
    }
}
