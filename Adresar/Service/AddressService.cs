using Data;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AddressService
    {
        private readonly AdresarContext _context;

        public AddressService(AdresarContext context)
        {
            context.Database.EnsureCreated();
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

        public async Task<Address> Create(AddressDTO address)
        {
            var newAddress = new Address
            {
                City = address.City,
                PostalCode = address.PostalCode,
                HouseNumber = address.HouseNumber,
                Street = address.Street,
                HouseNumberAddon = address.HouseNumberAddon
            };

            await _context.Addresses.AddAsync(newAddress);
            await _context.SaveChangesAsync();

            return await Get(newAddress.Id);
        }

        public async Task<Address> Update(Guid id, AddressDTO address)
        {
            var entity = await Get(id);

            entity.City = address.City;
            entity.Street = address.Street;
            entity.HouseNumber = address.HouseNumber;
            entity.HouseNumberAddon = address.HouseNumberAddon;
            entity.PostalCode = address.PostalCode;

            await _context.SaveChangesAsync();

            return await Get(id);
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