using AutoMapper;
using webapi_01.Dtos.Character;
using webapi_01.Models;

namespace webapi_01.Profiler
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
        }
    }
}