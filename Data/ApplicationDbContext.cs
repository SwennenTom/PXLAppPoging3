using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PXLApp.Models;

namespace PXLApp3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AcademieJaar> academieJaren { get; set; }
        public DbSet<Gebruiker> gebruikers { get; set; }
        public DbSet<Handboek> handboeken { get; set; }
        public DbSet<Vak> vakken { get; set; }
        public DbSet<Lector> lectors { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<VakLector> vakLectoren { get; set; }
        public DbSet<Inschrijving> inschrijvingen { get; set; }
    }
}