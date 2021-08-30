using AspnetCore.Healthchecks.Metrics.Data.DataContexts;
using AspnetCore.Healthchecks.Metrics.Domain.Entities;
using AspnetCore.Healthchecks.Metrics.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<Address> ListAddressAsync(string cep)
            => await _context.Address.AsNoTracking().FirstOrDefaultAsync(a => a.CEP.Equals(cep));

        public async Task<IEnumerable<Address>> ListAddressesAync()
            => await _context.Address.AsNoTracking().ToListAsync();

        public async Task SaveAddressAsync(Address address)
        {
            await _context.Address.AddAsync(address);
            await _context.SaveChangesAsync();
        }
    }
}
