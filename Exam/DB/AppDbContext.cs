using Microsoft.EntityFrameworkCore;
using Models.models;

namespace DB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Monster> Monsters { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=dotnet;Username=postgres;Password=postgres");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var goblin = new Monster
        {
            Id = 1,
            Name = "Goblin",
            HitPoints = 7,
            AttackModifier = 4,
            AttackPerRound = 1,
            Damage = "1d6",
            DamageModifier = 2,
            ArmorClass = 15
        };

        var gnoll = new Monster
        {
            Id = 2,
            Name = "Gnoll",
            HitPoints = 22,
            AttackModifier = 4,
            AttackPerRound = 1,
            Damage = "1d6",
            DamageModifier = 2,
            ArmorClass = 15
        };

        var hobgoblinWarlord = new Monster
        {
            Id = 3,
            Name = "Hobgoblin warlord",
            HitPoints = 97 ,
            AttackModifier = 9,
            AttackPerRound = 3,
            Damage = "1d8",
            DamageModifier = 3,
            ArmorClass = 20
        };

        var bugbear = new Monster
        {
            Id = 4,
            Name = "Bugbear",
            HitPoints = 27 ,
            AttackModifier = 4,
            AttackPerRound = 1,
            Damage = "2d8",
            DamageModifier = 2,
            ArmorClass = 16
        };

        modelBuilder.Entity<Monster>().HasData(goblin, gnoll, hobgoblinWarlord, bugbear);
    }
}