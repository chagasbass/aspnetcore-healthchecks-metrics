using AspnetCore.Healthchecks.Metrics.Data.DataContexts;
using AspnetCore.Healthchecks.Metrics.Domain.Entities;
using AspnetCore.Healthchecks.Metrics.Domain.Repositories;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SaveAddressAsync(Address address)
        {
            await _context.Address.AddAsync(address);
            await _context.SaveChangesAsync();
        }
    }
}
