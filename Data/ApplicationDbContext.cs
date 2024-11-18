using ASP_NET_Bakalarka.Models;
using EvidenciaStudentov.Models;
using Microsoft.EntityFrameworkCore;

namespace EvidenciaStudentov.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Pouzivatel> Pouzivatelia { get; set; }
        public DbSet<Rola> Rola { get; set; }
        public DbSet<Predmet> Predmety { get; set; }
        public DbSet<PriradeniePredmetovUcitelom> PriradeniaPredmetovUcitelom { get; set; }
        public DbSet<PriradeniePredmetovZiakom> PriradeniaPredmetovZiakom { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Vzťah medzi učiteľmi a predmetmi
            modelBuilder.Entity<PriradeniePredmetovUcitelom>()
                .HasOne(p => p.Ucitel)
                .WithMany(u => u.PriradenePredmetyUcitelom)
                .HasForeignKey(p => p.UcitelId);

            modelBuilder.Entity<PriradeniePredmetovUcitelom>()
                .HasOne(p => p.Predmet)
                .WithMany(pr => pr.PriradeneUcitelom)
                .HasForeignKey(p => p.PredmetId);

            // Vzťah medzi žiakmi a predmetmi
            modelBuilder.Entity<PriradeniePredmetovZiakom>()
                .HasOne(p => p.Ziak)
                .WithMany(u => u.PriradenePredmetyZiakom)
                .HasForeignKey(p => p.ZiakId);

            modelBuilder.Entity<PriradeniePredmetovZiakom>()
                .HasOne(p => p.Predmet)
                .WithMany(pr => pr.PriradeneZiakom)
                .HasForeignKey(p => p.PredmetId);

            // Vzťah medzi používateľmi a rolami
            modelBuilder.Entity<Pouzivatel>()
                .HasOne(p => p.Rola)
                .WithMany(r => r.Pouzivatelia)
                .HasForeignKey(p => p.RolaId);

            // Seedovanie predvolených rolí
            modelBuilder.Entity<Rola>().HasData(
                new Rola { RolaId = 1, Nazov = "Admin" },
                new Rola { RolaId = 2, Nazov = "Učiteľ" },
                new Rola { RolaId = 3, Nazov = "Žiak" }
            );


        }
    }
}