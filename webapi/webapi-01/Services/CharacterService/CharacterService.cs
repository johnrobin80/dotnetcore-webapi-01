using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_01.Dtos.Character;
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

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            // var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            // characters.Add(_mapper.Map<Character>(newCharacter));
            // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            // return serviceResponse;

            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = (characters.Max(c => c.Id)) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Message = "Data with id:" + character.Id.ToString() + " has been added successfully..";
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);
                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                serviceResponse.Message = "Data with id:" + id.ToString() + " has been deleted successfully..";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {

                Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                serviceResponse.Message = "Data with id:" + character.Id.ToString() + " has been updated successfully..";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        // public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        // {
        //     var serviceResponse = new ServiceResponse<List<Character>>();
        //     characters.Add(newCharacter);
        //     serviceResponse.Data = characters;
        //     return serviceResponse;

        // }

        // public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        // {
        //     var serviceResponse = new ServiceResponse<List<Character>>();
        //     serviceResponse.Data = characters;
        //     return serviceResponse;
        // }

        // public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        // {
        //     var serviceResponse = new ServiceResponse<Character>();
        //     serviceResponse.Data = characters.FirstOrDefault(c => c.Id == id);
        //     return serviceResponse;
        // }
    }
}