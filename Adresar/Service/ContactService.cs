using Data;
using Date;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ContactService
    {
        private readonly AdresarContext _context;

        public ContactService(AdresarContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> Get(Guid id)
        {
            return await _context.Contacts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact> Create(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return await Get(contact.Id);
        }

        public async Task<Contact> Update(Guid id, Contact contact)
        {
            var entity = await Get(contact.Id);

            entity.Name = contact.Name;
            entity.Surname = contact.Surname;
            entity.Mobile = contact.Mobile;

            await _context.SaveChangesAsync();

            return await Get(contact.Id);
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