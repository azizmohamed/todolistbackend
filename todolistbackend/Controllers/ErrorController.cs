using System;
using Microsoft.AspNetCore.Mvc;

namespace todolistbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error() => Problem();
    }
}
