using UnitTestExample.Models;

namespace UnitTestExample.DataAccess.IRepository
{
    public interface IContactRepository : IRepositoryAsync<Contact>
    {
        Task<Contact> UpdateAsync(Contact contact);
    }
}
