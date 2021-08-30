using AspnetCore.Healthchecks.Metrics.ApplicationServices.Dtos;
using AspnetCore.Healthchecks.Metrics.ApplicationServices.Factories;
using AspnetCore.Healthchecks.Metrics.Domain.Repositories;
using AspnetCore.Healthchecks.Metrics.Domain.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.ApplicationServices.Services
{
    public class AddressAplicationService : IAddressAplicationService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressExternalService _addressExternalService;
        private readonly IMapper _mapper;
        private readonly AddressFactory _addressFactory;

        public AddressAplicationService(IAddressRepository addressRepository,
                                        IAddressExternalService addressExternalService, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _addressExternalService = addressExternalService;
            _mapper = mapper;

            _addressFactory = new AddressFactory(_mapper);
        }

        public async Task<IEnumerable<AddressQueryDto>> ListAddressesAsync()
        {
            var addresses = await _addressRepository.ListAddressesAync();

            return _addressFactory.CreateAddressQueryDtos(addresses.ToList());
        }

        public async Task<string> SaveAddressAsync(AddressDto addressDto)
        {
            var queryAddress = await _addressRepository.ListAddressAsync(addressDto.Cep);

            if (queryAddress is not null)
                return $"Endereço já cadastrado ID = {queryAddress.Id} RUA: {queryAddress.Street} ,{queryAddress.District} - {queryAddress.City}";

            var foundedAddress = await _addressExternalService.GetAddressByCepAsync(addressDto.Cep);

            if (foundedAddress is null)
                return default;

            var newAddress = _addressFactory.CreateAddress(foundedAddress);

            await _addressRepository.SaveAddressAsync(newAddress);

            return $"Endereço  cadastrado com sucesso ID = {newAddress.Id} RUA: {newAddress.Street},{newAddress.District} - {newAddress.City}";
        }
    }
}
