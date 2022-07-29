using UnitTestExample.Models;

namespace UnitTestExample.DataAccess.IRepository
{
    public interface ITestingRepository : IRepositoryAsync<Testing>
    {
        Task<Testing> UpdateAsync(Testing testing);
    }
}
