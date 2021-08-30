using AspnetCore.Healthchecks.Metrics.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task SaveAddressAsync(Address address);
        Task<IEnumerable<Address>> ListAddressesAync();
        Task<Address> ListAddressAsync(string cep);
    }
}
