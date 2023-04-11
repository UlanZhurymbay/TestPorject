using Microsoft.EntityFrameworkCore;
using TestDemo.Models.Entities;

namespace TestDemo.Models.Data;

public class TestContext : DbContext
{
    public TestContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<R_CURRENCY> RCurrencies { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<R_CURRENCY>()
            .Property(t => t.Code)
            .IsRequired();
        modelBuilder.Entity<R_CURRENCY>()
            .Property(t => t.Title)
            .IsRequired();
        modelBuilder.Entity<R_CURRENCY>()
            .Property(t => t.Value)
            .IsRequired();
        modelBuilder.Entity<R_CURRENCY>()
            .Property(t => t.A_Date)
            .IsRequired();
    }
}