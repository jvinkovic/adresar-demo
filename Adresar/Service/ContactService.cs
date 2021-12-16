using Data;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ContactService
    {
        private readonly AdresarContext _context;

        public ContactService(AdresarContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> Get(Guid id)
        {
            return await _context.Contacts.Include(c => c.Address).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact> Create(ContactDTO contact)
        {
            var newContact = new Contact
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Mobile = contact.Mobile,
                AddressId = contact.AddressId
            };

            await _context.Contacts.AddAsync(newContact);
            await _context.SaveChangesAsync();

            return await Get(newContact.Id);
        }

        public async Task<Contact> Update(Guid id, ContactDTO contact)
        {
            var entity = await Get(id);

            entity.Name = contact.Name;
            entity.Surname = contact.Surname;
            entity.Mobile = contact.Mobile;
            entity.AddressId = contact.AddressId;

            await _context.SaveChangesAsync();

            return await Get(id);
        }

        public async Task Delete(Guid id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _context.Contacts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}