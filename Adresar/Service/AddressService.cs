using Data;
using Date;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AddressService
    {
        private readonly AdresarContext _context;

        public AddressService(AdresarContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> Get(Guid id)
        {
            return await _context.Addresses.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address> Create(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return await Get(address.Id);
        }

        public async Task<Address> Update(Guid id, Address address)
        {
            var entity = await Get(address.Id);

            entity.City = address.City;
            entity.Street = address.Street;
            entity.HouseNumber = address.HouseNumber;
            entity.HouseNumberAddon = address.HouseNumberAddon;
            entity.PostalCode = address.PostalCode;

            await _context.SaveChangesAsync();

            return await Get(address.Id);
        }

        public async Task Delete(Guid id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _context.Addresses.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}