using Microsoft.AspNetCore.Mvc;
using webapi_01.Models;

namespace webapi_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
    private static Character knight = new Character();
    public IActionResult Get()
    {
       return Ok(knight);
    }
      
    }
}