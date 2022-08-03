# Unit Test & Selenium WebDriver

The project is developed in **ASP.net Core MVC with razor pages**
> .Net 6, C#, Bootstrap 5, Swagger, SQL LocalDB, Repository Pattern, Data Seeder, MSTest, MOQ, Selenium WebDriver

DbContext **UnitTestExample.DataAccess**
> Open *Package Manager Console* and run the below command to generate SQL LocalDB and sample data. SQL LocalDB or SQL Server both can be used. Review *appsettings.json* for connection string.
```
Update-Database
```

**Swagger**
> Review swagger for API endpoints. It could be used for manual api testing.
```
/swagger/index.html
```

**How to use MSTest**
- Goto "View"
- Find "Test Explorer" from the list
- Run the application without debug (ctrl+f5) than run the test. You can change it to IIS url (Ex. http://pwa.local.localhost.com) in UI Test classes if you want to run test without runing the application.
There is an option for run or debug test case. I have used MOQ for api, repository, service and function testing, it will not use real data or insert real data. It will just go through the function and check for expected result.

**Ordering your test suite and test cases**
> A test named Test14 will run before Test2 even though the number 2 is less than 14. This is because, test name ordering uses the text name of the test.

**Configure MSTest for new application**
> Make sure to add below line in DbContext if you are planing to test Repository
```
 public ApplicationDbContext() { }
```
It will look something like below.
```
    public class ApplicationDbContext : DbContext
    {
		//this is required for repository testing
        public ApplicationDbContext() { }
		
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
   
        public DbSet<Testing> Testings { get; set; }
   }
```
