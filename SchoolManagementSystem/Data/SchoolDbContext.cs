using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using Microsoft.Extensions.Configuration;
using SchoolManagementSystem.Models.IntermediateTables;


namespace SchoolManagementSystem.Data;

public class SchoolDbContext : DbContext
{
    // public SchoolDbContext(DbContextOptions options) : base(options) {}
    private IConfiguration _configuration;
    public SchoolDbContext (IConfiguration iconfig)
    {
        _configuration = iconfig;
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Admin> Admins { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Grade> Grades { get; set; } = null!;
    public DbSet<Absence> Absences { get; set; } = null!;
    public DbSet<StudentSubject> StudentSubjects { get; set; } = null!;
    public DbSet<TeacherSubject> TeacherSubjects { get; set; } = null!;
    public DbSet<StudentEvent> StudentEvents { get; set; } = null!;
    public DbSet<TeacherEvent> TeacherEvents { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =  _configuration.GetConnectionString("SchoolDb");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        builder.Entity<Student>()
            .HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<Student>(s => s.StudentId);
        builder.Entity<Teacher>()
            .HasOne(t => t.User)
            .WithOne()
            .HasForeignKey<Teacher>(t => t.TeacherId);
        builder.Entity<Admin>()
            .HasOne(a => a.User)
            .WithOne()
            .HasForeignKey<Admin>(a => a.AdminId);
    }
    public DbSet<SchoolManagementSystem.Models.Grade>? Grade { get; set; }
}