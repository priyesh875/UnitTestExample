// <auto-generated />
using System;
using UnitTestExample.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace UnitTestExample.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220723065657_Contacts_Fix")]
    partial class Contacts_Fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UnitTestExample.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Disney"
                        },
                        new
                        {
                            Id = 2,
                            Name = "HP"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Microsoft"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Google"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Facebook"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Tesla"
                        });
                });

            modelBuilder.Entity("UnitTestExample.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastDateContacted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "112 Main St",
                            Comments = "Lorem Ipsum is simply dummy text of the printing.",
                            CompanyId = 1,
                            Email = "walter@disney.com",
                            JobTitle = "Founder & CEO",
                            LastDateContacted = new DateTime(2022, 7, 23, 1, 56, 57, 97, DateTimeKind.Local).AddTicks(1736),
                            Name = "Walter Disney",
                            Phone = "444-444-5599"
                        },
                        new
                        {
                            Id = 2,
                            Address = "7775 Main St",
                            Comments = "Contrary to popular belief, Lorem Ipsum is not simply random text.",
                            CompanyId = 2,
                            Email = "mary@smith.com",
                            JobTitle = "VP Finance",
                            LastDateContacted = new DateTime(2022, 7, 23, 1, 56, 57, 97, DateTimeKind.Local).AddTicks(1770),
                            Name = "Mary Smith",
                            Phone = "433-544-5599"
                        });
                });

            modelBuilder.Entity("UnitTestExample.Models.Testing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Testings");
                });

            modelBuilder.Entity("UnitTestExample.Models.Contact", b =>
                {
                    b.HasOne("UnitTestExample.Models.Company", "Company")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("UnitTestExample.Models.Company", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
