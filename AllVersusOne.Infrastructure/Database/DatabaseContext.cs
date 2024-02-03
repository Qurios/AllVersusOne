using AllVersusOne.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AllVersusOne.Infrastructure.Database;

public class DatabaseContext: DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<GameRound> GameRounds { get; set; }
    public DbSet<Guess> Guesses { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}