using UnitTestExample.DataAccess.Data;
using UnitTestExample.DataAccess.IRepository;
using UnitTestExample.Models;

namespace UnitTestExample.DataAccess.Repository
{
    public class TestingRepository : RepositoryAsync<Testing>, ITestingRepository
    {
        private readonly ApplicationDbContext _db;
        public TestingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Testing> UpdateAsync(Testing testing)
        {
            if (testing == null)
                return null;
            var exist = await _db.Set<Testing>().FindAsync(testing.Id);
            if (exist != null)
            {
                _db.Entry(exist).CurrentValues.SetValues(testing);
                await _db.SaveChangesAsync();
            }
            return exist;
        }
    }
}
