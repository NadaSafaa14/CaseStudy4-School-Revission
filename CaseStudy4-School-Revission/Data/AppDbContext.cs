using CaseStudy4_School_Revission.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4_School_Revission.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);
            
            modelBuilder.Entity<Course>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.StudentProfile)
                .WithOne(s => s.Student)
                .HasForeignKey<StudentProfile>(s => s.StudentId);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);

            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new
                {
                    e.StudentId, e.CourseId
                }).IsUnique();
            
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();
            
            modelBuilder.Entity<Teacher>()
                .HasIndex(t => t.Email)
                .IsUnique();
        }
    }
}
