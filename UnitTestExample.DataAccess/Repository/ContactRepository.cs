using UnitTestExample.DataAccess.Data;
using UnitTestExample.DataAccess.IRepository;
using UnitTestExample.Models;

namespace UnitTestExample.DataAccess.Repository
{
    public class ContactRepository : RepositoryAsync<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _db;
        public ContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Contact> UpdateAsync(Contact contact)
        {
            if (contact == null)
                return null;
            var exist = await _db.Set<Contact>().FindAsync(contact.Id);
            if (exist != null)
            {
                _db.Entry(exist).CurrentValues.SetValues(contact);
                await _db.SaveChangesAsync();
            }
            return exist;
        }
    }
}
