using ContosoUniversityYanShapovalov12.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityYanShapovalov12.Data
{
    public class SchoolContext:DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Student>Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
        }

    }
}
