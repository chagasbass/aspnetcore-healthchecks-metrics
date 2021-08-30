using AspnetCore.Healthchecks.Metrics.ApplicationServices.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.ApplicationServices.Services
{
    public interface IAddressAplicationService
    {
        Task<string> SaveAddressAsync(AddressDto addressDto);
        Task<IEnumerable<AddressQueryDto>> ListAddressesAsync();
    }
}
