using Microsoft.EntityFrameworkCore;

public class RMContext : DbContext
{
    public RMContext(DbContextOptions<RMContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}