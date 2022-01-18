using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_01.Dtos.Character;
using webapi_01.Models;
using webapi_01.Services.CharacterService;

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

        // private static List<Character> characters = new List<Character>{
        //     new Character(),
        //     new Character{Id=1,Name="Test1",HitPoints=100000,Class = RpgClass.Knight},
        //     new Character{Id=2,Name="Test2",HitPoints=200000,Class = RpgClass.Mage},
        //     new Character{Id=3,Name="Test3",HitPoints=300000,Class = RpgClass.Cleric}
        // };
        private readonly ICharacterService _charaterService;

        public CharacterController(ICharacterService charaterService)
        {
            _charaterService = charaterService;

        }

        [HttpGet("GetAll")]
        //[Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            //return Ok(characters);
            return Ok(await _charaterService.GetAllCharacters());
        }

        // [HttpGet]
        // public ActionResult<Character> GetSingle()
        // {
        // return Ok(characters[0]);
        // }

        [HttpGet("GetById")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            // return Ok(characters.FirstOrDefault(c => c.Id == id));
            return Ok(await _charaterService.GetCharacterById(id));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            //characters.Add(newCharacter);
            //return Ok(characters);
            return Ok(await _charaterService.AddCharacter(newCharacter));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            //characters.Add(newCharacter);
            //return Ok(characters);
            //return Ok(await _charaterService.UpdateCharacter(updateCharacter));
            var response = await _charaterService.UpdateCharacter(updateCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await _charaterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}