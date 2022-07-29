namespace UnitTestExample.DataAccess.IRepository
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ITestingRepository Testing { get; }
        ICompanyRepository Company { get; }
        IContactRepository Contact { get; }
        Task SaveChangesAsync();
    }
}
