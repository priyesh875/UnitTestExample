using UnitTestExample.DataAccess.Data;
using UnitTestExample.DataAccess.IRepository;

namespace UnitTestExample.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Testing = new TestingRepository(_db);
            Company = new CompanyRepository(_db);
            Contact = new ContactRepository(_db);
        }

        public ITestingRepository Testing { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IContactRepository Contact { get; private set; }

        public async ValueTask DisposeAsync()
        {
            await _db.DisposeAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
