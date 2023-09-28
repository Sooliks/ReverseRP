using System.Diagnostics;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MySql.Data.MySqlClient;
using ServerSide.Database.Models;
using ServerSide.Database.ModelsConfiguration;
using ServerSide.Inventory.Items;

namespace ServerSide.Database;

public class Context : DbContext
{
    public DbSet<Account> Account { get; set; }
    public DbSet<Character> Character { get; set; }
    public DbSet<ItemBase> ItemBase { get; set; }
    

    public Context()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Database = "reverserp",
            Port = 3306,
            UserID = "root",
            Password = "",
        };
        optionsBuilder.UseMySQL(connectionString.ConnectionString)
            .LogTo(str => Debug.WriteLine(str), new[] { RelationalEventId.CommandExecuted })
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new ItemBaseConfiguration());
        
        modelBuilder.Entity<Ammo>().HasBaseType<ItemBase>();
        modelBuilder.Entity<Food>().HasBaseType<ItemBase>();
        modelBuilder.Entity<Gun>().HasBaseType<ItemBase>();
    }
}