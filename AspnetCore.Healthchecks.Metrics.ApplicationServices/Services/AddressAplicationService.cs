using AspnetCore.Healthchecks.Metrics.ApplicationServices.Dtos;
using AspnetCore.Healthchecks.Metrics.ApplicationServices.Factories;
using AspnetCore.Healthchecks.Metrics.Domain.Repositories;
using AspnetCore.Healthchecks.Metrics.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.ApplicationServices.Services
{
    public class AddressAplicationService : IAddressAplicationService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressExternalService _addressExternalService;

        public AddressAplicationService(IAddressRepository addressRepository,
                                        IAddressExternalService addressExternalService)
        {
            _addressRepository = addressRepository;
            _addressExternalService = addressExternalService;
        }

        public async Task<IEnumerable<AddressQueryDto>> ListAddressesAsync()
        {
            var addresses = await _addressRepository.ListAddressesAync();

            return AddressFactory.CreateAddressQueryDtos(addresses.ToList());
        }

        public async Task<string> SaveAddressAsync(AddressDto addressDto)
        {
            var queryAddress = await _addressRepository.ListAddressAsync(addressDto.Cep);

            if (queryAddress is not null)
            {
                return $"Endereço já cadastrado ID = {queryAddress.Id}";
            }

            var foundedAddress = await _addressExternalService.GetAddressByCepAsync(addressDto.Cep);

            if (foundedAddress is null)
                return default;

            var newAddress = AddressFactory.CreateAddress(foundedAddress);

            await _addressRepository.SaveAddressAsync(newAddress);

            return $"Endereço  cadastrado com sucesso ID = {newAddress.Id}";
        }
    }
}
