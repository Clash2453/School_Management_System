using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using Microsoft.Extensions.Configuration;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models.IntermediateTables;


namespace SchoolManagementSystem.Data;

public class SchoolDbContext : DbContext
{
    // public SchoolDbContext(DbContextOptions options) : base(options)  {}
    private readonly IConfiguration _configuration;
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
    public DbSet<Faculty> Faculties { get; set; } = null!;
    public DbSet<Major> Majors { get; set; } = null!;
    public DbSet<SubjectMajor> SubjectMajors { get; set; } = null!;
    public DbSet<TeacherSubject> TeacherSubjects { get; set; } = null!;
    public DbSet<StudentEvent> StudentEvents { get; set; } = null!;
    public DbSet<TeacherEvent> TeacherEvents { get; set; } = null!;
    public DbSet<UserFile> UserFiles { get; set; } = null!;
    public DbSet<Institution> Institutions { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =  _configuration.GetConnectionString("SchoolDb");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        //User relations
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

        //Grade enum conversion rule
        builder
            .Entity<Grade>()
            .Property(g => g.TypeOfGrade)
            .HasConversion(
                v => v.ToString(),
            v => (GradeType)Enum.Parse(typeof(GradeType), v));

        //User files
        builder.Entity<UserFile>()
            .HasOne(f => f.User)
            .WithOne()
            .HasForeignKey<UserFile>(u => u.UserId);


        builder
            .Entity<Institution>()
            .HasMany(i => i.Teachers)
            .WithMany();
        
        builder
            .Entity<Institution>()
            .HasMany(i => i.MajorsOffered)
            .WithMany();

    }
}