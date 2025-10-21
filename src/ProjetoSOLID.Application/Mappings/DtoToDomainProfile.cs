using AutoMapper;
using ProjetoSOLID.Domain.DTOs;
using ProjetoSOLID.Domain.Entities;

namespace ProjetoSOLID.Application.Mappings
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<ClienteDto, Cliente>();
        }
    }
}
