using FuelStation.EF.Configuration;
using FuelStation.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Context;

public class FuelStationContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Item> Items { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<TransactionLine> TransactionLines { get; set; }

    public DbSet<Login> Logins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionLineConfiguration());
        modelBuilder.ApplyConfiguration(new LoginConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbFuelStation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        optionsBuilder.UseSqlServer(connString);
    }
}
