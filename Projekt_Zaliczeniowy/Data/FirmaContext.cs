using Microsoft.EntityFrameworkCore;
using Projekt_Zaliczeniowy.Models;

namespace Projekt_Zaliczeniowy.Data
{
    public class FirmaContext : DbContext
    {
        public DbSet<Komputer> Komputery { get; set; }
        public DbSet<Oprogramowanie> Programy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=firma.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Komputer>().HasData(
                new Komputer { KomputerId = 1, Nazwa = "PC001", Dzial = "Księgowość", Uzytkownik = "Jan Kowalski" },
                new Komputer { KomputerId = 2, Nazwa = "PC002", Dzial = "IT", Uzytkownik = "Anna Nowak" }
            );

            modelBuilder.Entity<Oprogramowanie>().HasData(
                new Oprogramowanie { OprogramowanieId = 1, KomputerId = 1, Nazwa = "MS Office", Wersja = "2019", TypLicencji = "OEM", DataInstalacji = new DateTime(2023, 1, 15) },
                new Oprogramowanie { OprogramowanieId = 2, KomputerId = 2, Nazwa = "Visual Studio", Wersja = "2022", TypLicencji = "MSDN", DataInstalacji = new DateTime(2024, 5, 5) }
            );
        }
    }
}