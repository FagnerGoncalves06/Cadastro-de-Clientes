using AutoMapper;
using ProjetoSOLID.Domain.DTOs;
using ProjetoSOLID.Domain.Entities;

namespace ProjetoSOLID.Application.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
