using Microsoft.EntityFrameworkCore;
using appComercial.Models;

namespace appComercial.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().ToTable("Curso");     
            modelBuilder.Entity<Docente>().ToTable("Docente"); 
        }
    }
}