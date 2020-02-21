using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleCRUD.Infra.Data.EFMigration
{
    public class EFMigrationDbContext : DbContext
    {
        public EFMigrationDbContext()
            : base()
        {

        }
        public DbSet<Domain.Entities.User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ExampleCRUD;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.User>(b =>
            {
                b.HasKey(u => u.Id);

                b.ToTable("User");

                b.Property(u => u.Name).HasMaxLength(500);
                b.Property(u => u.Email).HasMaxLength(500);


            });

            modelBuilder.Entity<Domain.Entities.User>().HasData(
                new Domain.Entities.User
                {
                    Id = 1,
                    Name = "Jose da Silva",
                    CpfCnpj = "902.522.530-60",
                    BirthDate = DateTime.Parse("1999-01-01"),
                    Actived = true,
                    Email = "josedasilva@email.com",
                    AddressCity = "Santos",
                    AddressNumber = "123",
                    AddressState = "SP",
                    AddressStreet = "Rua das Mares",
                    AddressZipCode = "05589-458",
                    Created = DateTime.Now
                },
                new Domain.Entities.User
                {
                    Id = 2,
                    Name = "Maria Jose Antunes",
                    CpfCnpj = "184.539.440-24",
                    BirthDate = DateTime.Parse("1975-08-05"),
                    Actived = true,
                    Email = "mariajoseantunes@emailtest.com",
                    AddressCity = "Manaus",
                    AddressNumber = "123",
                    AddressState = "AM",
                    AddressStreet = "Rua Caiapó",
                    AddressZipCode = "77788-858",
                    Created = DateTime.Now
                },
                new Domain.Entities.User
                {
                    Id = 3,
                    Name = "Mohamed Li",
                    CpfCnpj = "587.573.110-99",
                    BirthDate = DateTime.Parse("1987-02-10"),
                    Actived = true,
                    Email = "mohamedli@testemail.com",
                    AddressCity = "São Paulo",
                    AddressNumber = "85",
                    AddressState = "SP",
                    AddressStreet = "Av. Paulista",
                    AddressZipCode = "99999-558",
                    Created = DateTime.Now
                }
                );
        }
    }
}
