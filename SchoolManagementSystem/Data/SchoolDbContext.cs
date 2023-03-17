using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using Microsoft.Extensions.Configuration;


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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =  _configuration.GetConnectionString("SchoolDb");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}