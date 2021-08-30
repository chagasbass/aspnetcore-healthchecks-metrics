using AspnetCore.Healthchecks.Metrics.ApplicationServices.Dtos;
using AspnetCore.Healthchecks.Metrics.Domain.Entities;
using AspnetCore.Healthchecks.Metrics.Domain.Queries;
using AutoMapper;
using System.Collections.Generic;

namespace AspnetCore.Healthchecks.Metrics.ApplicationServices.Factories
{
    public class AddressFactory
    {
        private readonly IMapper _mapper;

        public AddressFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<AddressQueryDto> CreateAddressQueryDtos(List<Address> addresses)
            => _mapper.Map<IEnumerable<AddressQueryDto>>(addresses);

        public Address CreateAddress(AddressQuery addressQuery) => _mapper.Map<Address>(addressQuery);
    }
}
