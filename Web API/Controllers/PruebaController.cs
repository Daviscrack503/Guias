using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {


        [HttpGet("beta")]
        public string Get()
        {
            return "Hola Mundo desde el controlador PruebaController";

        }
            

    }
}
