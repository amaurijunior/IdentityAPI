using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class AccessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Acesso Permitido");
        }
    }
}
