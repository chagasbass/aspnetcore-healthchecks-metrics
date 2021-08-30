using AspnetCore.Healthchecks.Metrics.ApplicationServices.Dtos;
using AspnetCore.Healthchecks.Metrics.Domain.Entities;
using AspnetCore.Healthchecks.Metrics.Domain.Queries;
using System.Collections.Generic;

namespace AspnetCore.Healthchecks.Metrics.ApplicationServices.Factories
{
    public static class AddressFactory
    {
        public static IEnumerable<AddressQueryDto> CreateAddressQueryDtos(List<Address> addresses)
        {
            var _addressQueryDtos = new List<AddressQueryDto>();

            addresses.ForEach(a =>
            {
                _addressQueryDtos.Add(new AddressQueryDto
                {
                    Id = a.Id,
                    CEP = a.CEP,
                    City = a.City,
                    District = a.District,
                    State = a.State,
                    Street = a.Street
                });
            });

            return _addressQueryDtos;
        }

        public static Address CreateAddress(AddressQuery addressQuery)
        {
            return new Address(addressQuery.Cep, addressQuery.Logradouro, addressQuery.Bairro, addressQuery.Localidade, addressQuery.Uf);
        }
    }
}
