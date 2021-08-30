using AspnetCore.Healthchecks.Metrics.Domain.Queries;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.Domain.Services
{
    public interface IAddressExternalService
    {
        Task<AddressQuery> GetAddressByCepAsync(string cep);
    }
}
