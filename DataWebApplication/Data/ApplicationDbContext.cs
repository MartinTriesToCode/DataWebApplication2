using Microsoft.EntityFrameworkCore;
using DataWebApplication.Models.Entities;
using System.Collections.Generic;

namespace DataWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {


        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(s => s.City)
                .WithMany(g => g.CityPeople)
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Person>()
                .HasOne(s => s.Country)
                .WithMany(g => g.CountryPeople)
                .HasForeignKey(s => s.CountryId);
            modelBuilder.Entity<City>()
                .HasOne(s => s.Country)
                .WithMany(g => g.Cities)
                .HasForeignKey(s => s.CountryId);



            modelBuilder.Entity<PersonLanguage>().HasKey(t => new { t.PersonId, t.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
            .HasOne(t => t.Person)
            .WithMany(t => t.PersonLanguages)
            .HasForeignKey(t => t.PersonId);
     

            modelBuilder.Entity<PersonLanguage>()
            .HasOne(t => t.Language)
            .WithMany(t => t.PersonLanguages)
            .HasForeignKey(t => t.LanguageId);


            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Sverige" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Norge" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "Tyskland" });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Boden", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Kiruna", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Star City", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { Id = 4, Name = "Oslo", CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { Id = 5, Name = "Kiel", CountryId = 4 });

            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "Martin", Phone = "0743123456", CityId = 1, CountryId = 1});
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Elon", Phone = "0777622344", CityId = 3, CountryId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Sven", Phone = "0743124125", CityId = 2, CountryId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, Name = "Hans", Phone = "0764312345", CityId = 5, CountryId = 4 });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 5, Name = "Björn", Phone = "0777622344", CityId = 4, CountryId = 3 });

            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, Name = "Svenska" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, Name = "Engelska" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, Name = "Norska" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, Name = "Tyska" });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 1, PersonId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 2, PersonId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 2, PersonId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 4, PersonId = 4 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 3, PersonId = 5 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 1, PersonId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 2, PersonId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 3, PersonId = 3 });
        }

    }
}

            

        


    

