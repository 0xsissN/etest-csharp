using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) { }
        public DbSet<Aptitud> Aptitudes { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Colegio> Colegios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<CarreraTest> CarreraTests { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
