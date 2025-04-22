using System.Reflection;
using Domain.Organizations;
using Microsoft.EntityFrameworkCore;

namespace Api;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ProjectState> Projects { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
    }
}