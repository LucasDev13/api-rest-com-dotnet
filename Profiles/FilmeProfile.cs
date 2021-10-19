using api_v1_dotNetFlix.Data.Dtos;
using api_v1_dotNetFlix.Models;
using AutoMapper;

namespace api_v1_dotNetFlix.Profiles
{
    
    public class FilmeProfile : Profile {
        public FilmeProfile(){
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}