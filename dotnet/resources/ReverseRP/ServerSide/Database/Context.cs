using System;
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using ServerSide.Data;
using ServerSide.Database.Models;
using ServerSide.Database.ModelsConfiguration;
using ServerSide.Inventory.Items;

namespace ServerSide.Database;

public class Context : DbContext
{
    public DbSet<Account> Account { get; set; }
    public DbSet<Character> Character { get; set; }
    public DbSet<ItemBase> ItemBase { get; set; }
    public DbSet<ItemType> ItemsTypes { get; set; }
    public DbSet<BusinessBase> BusinessesBase { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<StatisticBusiness> StatisticBusinesses { get; set; }
    

    public Context()
    {
        //Database.EnsureDeleted();
        if (Database.EnsureCreated())
        {
            Console.WriteLine("DB CREATED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            using Context db = new Context();
            db.BusinessesBase.AddRange(BusinessesData.BusinessesDefault);
            db.ItemsTypes.AddRange(ItemsTypesData.ItemsMarket);
            db.SaveChanges();
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string json = "";
        using (var r = new StreamReader("dotnet/resources/ReverseRP/ServerSide/Data/conf.json"))
        {
            json = r.ReadToEnd();
        }
        var obj = JObject.Parse(json);
        var connectionString = new MySqlConnectionStringBuilder()
        {
            Server = (string)obj["database"]["server"],
            Database = (string)obj["database"]["database"],
            Port = (uint)obj["database"]["port"],
            UserID = (string)obj["database"]["userId"],
            Password = (string)obj["database"]["password"],
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
        modelBuilder.ApplyConfiguration(new ItemTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessesConfiguration());
        modelBuilder.ApplyConfiguration(new StatisticBusinessConfiguration());
        
        modelBuilder.Entity<Ammo>().HasBaseType<ItemType>();
        modelBuilder.Entity<Food>().HasBaseType<ItemType>();
        modelBuilder.Entity<Gun>().HasBaseType<ItemType>();
        modelBuilder.Entity<Medkit>().HasBaseType<ItemType>();
        
    }
}