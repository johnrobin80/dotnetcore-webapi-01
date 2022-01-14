using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webapi_01.Models;

namespace webapi_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
    // private static Character knight = new Character();

    // [HttpGet]
    // public ActionResult<Character> Get()
    // {
    //    return Ok(knight);
    // }

        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id=1,Name="Test1",HitPoints=100000,Class = RpgClass.Knight},
            new Character{Id=2,Name="Test2",HitPoints=200000,Class = RpgClass.Mage},
            new Character{Id=3,Name="Test3",HitPoints=300000,Class = RpgClass.Cleric}
        };

    [HttpGet("GetAll")]
    //[Route("GetAll")]
    public ActionResult<Character> Get()
    {
       return Ok(characters);
    }

    // [HttpGet]
    // public ActionResult<Character> GetSingle()
    // {
    // return Ok(characters[0]);
    // }

    [HttpGet("{id}")]
    public ActionResult<Character> GetSingle(int id)
    {
    return Ok(characters.FirstOrDefault(c => c.Id == id));
    }
      
    }
}