using AspnetCore.Healthchecks.Metrics.Domain.Entities;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task SaveAddressAsync(Address address);
    }
}
