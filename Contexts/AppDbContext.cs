using Microsoft.EntityFrameworkCore;
using PcConfiguratorApi.Models;

namespace PcConfiguratorApi.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PCComponent>()
            .HasKey(pc => new {pc.PCId, pc.ComponentCode});
        modelBuilder.Entity<PCComponent>()
            .HasOne(pcc => pcc.Pc)
            .WithMany(pc => pc.PCComponents)
            .HasForeignKey(pcc => pcc.PCId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<PCComponent>()
            .HasOne(pcc => pcc.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pcc => pcc.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Component>()
            .HasOne(c => c.ComponentType)
            .WithMany(c => c.Components)
            .HasForeignKey(c => c.ComponentTypesId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Component>()
            .HasOne(c => c.ComponentManufacturer)
            .WithMany(cm => cm.Components)
            .HasForeignKey(c => c.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
        );
        
        modelBuilder.Entity<ComponentManufacturer>().HasData(
        new ComponentManufacturer { Id = 1, Abbreviation = "INTC", FullName = "Intel Corporation", FoundationDate = new DateTime(1968, 7, 18) },
        new ComponentManufacturer { Id = 2, Abbreviation = "NVDA", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 4, 5) },
        new ComponentManufacturer { Id = 3, Abbreviation = "CRU", FullName = "Crucial Technology", FoundationDate = new DateTime(1996, 9, 25) }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = DateTime.Parse("2026-05-08T09:00:00"), Stock = 5 },
            new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = DateTime.Parse("2026-04-15T13:30:00"), Stock = 28 },
            new PC { Id = 3, Name = "Budget Starter", Weight = 8.0f, Warranty = 12, CreatedAt = DateTime.Parse("2026-01-10T10:00:00"), Stock = 67 }
        );
        
        modelBuilder.Entity<Component>().HasData(
            new Component { Code = "I914900K", Name = "Intel Core i9-14900K", Description = "Desktop Processor 24 Cores", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component { Code = "RTX4090", Name = "NVIDIA GeForce RTX 4090", Description = "Flagship Gaming Graphics Card", ComponentManufacturersId = 2, ComponentTypesId = 2 },
            new Component { Code = "CRU32GBD5", Name = "Crucial DDR5 Pro 32GB", Description = "High-performance Desktop Memory", ComponentManufacturersId = 3, ComponentTypesId = 3 }
        );

        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "I914900K", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RTX4090", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "CRU32GBD5", Amount = 2 }
        );
    }
}