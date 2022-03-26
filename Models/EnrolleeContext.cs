using Microsoft.EntityFrameworkCore;

namespace GraduateWorkApplication.Models
{
    public class EnrolleeContext : DbContext
    {
        public DbSet<Enrollee> Enrollees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public EnrolleeContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=d:\enrollee.db;foreign keys=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollee>()
                .HasOne(p => p.Group)
                .WithMany(t => t.Enrollees)
                .HasForeignKey(p => p.GroupKey);
        }
    }
}
