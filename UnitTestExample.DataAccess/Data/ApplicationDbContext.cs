using Microsoft.EntityFrameworkCore;
using UnitTestExample.Models;

namespace UnitTestExample.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasData(
                    new Company
                    {
                        Id = 1,
                        Name = "Disney"
                    },
                    new Company
                    {
                        Id = 2,
                        Name = "HP"
                    },
                    new Company
                    {
                        Id = 3,
                        Name = "Microsoft"
                    },
                    new Company
                    {
                        Id = 4,
                        Name = "Google"
                    },
                    new Company
                    {
                        Id = 5,
                        Name = "Facebook"
                    }
                    ,
                    new Company
                    {
                        Id = 6,
                        Name = "Tesla"
                    }
                );

            modelBuilder.Entity<Contact>(
                  entity =>
                  {
                      entity.HasOne(d => d.Company)
                          .WithMany(p => p.Contacts)
                          .HasForeignKey("CompanyId");
                  });


            modelBuilder.Entity<Contact>()
               .HasData(
                    new Contact
                    {
                        Id = 1,
                        Name = "Walter Disney",
                        JobTitle = "Founder & CEO",
                        CompanyId = 1,
                        Phone = "444-444-5599",
                        Address = "112 Main St",
                        Email = "walter@disney.com",
                        LastDateContacted = DateTime.Now,
                        Comments = "Lorem Ipsum is simply dummy text of the printing."
                    },
                    new Contact
                    {
                        Id = 2,
                        Name = "Mary Smith",
                        JobTitle = "VP Finance",
                        CompanyId = 2,
                        Phone = "433-544-5599",
                        Address = "7775 Main St",
                        Email = "mary@smith.com",
                        LastDateContacted = DateTime.Now,
                        Comments = "Contrary to popular belief, Lorem Ipsum is not simply random text."
                    }
               );
        }

        public DbSet<Testing> Testings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
