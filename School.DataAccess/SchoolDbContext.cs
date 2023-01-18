using Microsoft.EntityFrameworkCore;
using School.Entities;

namespace School.DataAccess
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<SchoolEntity> Schools { get; set; }
        public DbSet<ScoreEntity> Scores { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<SubjectEntity> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=EF.School;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
