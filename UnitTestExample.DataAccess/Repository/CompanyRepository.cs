using UnitTestExample.DataAccess.Data;
using UnitTestExample.DataAccess.IRepository;
using UnitTestExample.Models;

namespace UnitTestExample.DataAccess.Repository
{
    public class CompanyRepository : RepositoryAsync<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
