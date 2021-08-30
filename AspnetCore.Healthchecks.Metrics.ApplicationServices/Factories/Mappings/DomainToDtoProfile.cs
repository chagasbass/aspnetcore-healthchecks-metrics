using AspnetCore.Healthchecks.Metrics.ApplicationServices.Dtos;
using AspnetCore.Healthchecks.Metrics.Domain.Entities;
using AspnetCore.Healthchecks.Metrics.Domain.Queries;
using AutoMapper;

namespace AspnetCore.Healthchecks.Metrics.ApplicationServices.Factories.Mappings
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<AddressQuery, Address>()
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Localidade))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Uf))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Logradouro));

            CreateMap<AddressQueryDto, Address>();
            CreateMap<Address, AddressQueryDto>();
        }
    }
}
