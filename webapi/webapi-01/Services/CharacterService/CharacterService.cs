using System.Collections.Generic;
using System.Linq;
using webapi_01.Models;

namespace webapi_01.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id=1,Name="Test1",HitPoints=100000,Class = RpgClass.Knight},
            new Character{Id=2,Name="Test2",HitPoints=200000,Class = RpgClass.Mage},
            new Character{Id=3,Name="Test3",HitPoints=300000,Class = RpgClass.Cleric}
        };
        public List<Character> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
            
        }

        public List<Character> GetAllCharacters()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}