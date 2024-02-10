// Install Entity Framework Core packages and configure DbContext

using JimmInvoTest.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class TaskDbContext : DbContext
{
    public DbSet<Taskss> Taskss{ get; set; }
    public DbSet<UserLogin> UserLogin { get; set; }

    private readonly IConfiguration _config;

    public TaskDbContext(DbContextOptions options, IConfiguration config) : base(options)
    {
        _config = config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("TaskDbConnection"));
    }
}
