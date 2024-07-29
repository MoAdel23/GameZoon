using GameZone.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GameZone.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    DbSet<Game> Games { get; set; }

    DbSet<Device> Devices { get; set; }

    DbSet<Category>  Categories { get; set; }

    DbSet<GameDevivce>  GameDevivces { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<GameDevivce>()
            .HasKey(e => new { e.GameId, e.DeviceId });

        builder.Entity<ApplicationUser>()
            .ToTable(name: "Users", schema: "security");

        builder.Entity<IdentityRole>()
            .ToTable(name: "Roles", schema: "security");

        builder.Entity<IdentityRoleClaim<string>>()
               .ToTable(name: "RoleClaims", schema: "security");

        builder.Entity<IdentityUserRole<string>>()
            .ToTable(name: "UserRoles", schema: "security");

        builder.Entity<IdentityUserLogin<string>>()
            .ToTable(name: "UserLogins", schema: "security");

        builder.Entity<IdentityUserToken<string>>()
            .ToTable(name: "UserTokens", schema: "security");

        builder.Entity<IdentityUserClaim<string>>()
            .ToTable(name: "UserClaims", schema: "security");




        builder.Entity<Category>()
            .HasData(new Category[]
            {
                new Category { Id = 1, Name = "Sports" },
                new Category { Id = 2, Name = "Action" },
                new Category { Id = 3, Name = "Adventure" },
                new Category { Id = 4, Name = "Racing" },
                new Category { Id = 5, Name = "Fighting" },
                new Category { Id = 6, Name = "Film" }
            });

        builder.Entity<Device>()
            .HasData(new []
            {
                new Device { Id = 1, Name = "PlayStation", Icon = "bi bi-playstation" },
                new Device { Id = 2, Name = "Xbox", Icon = "bi bi-xbox" },
                new Device { Id = 3, Name = "Nintendo Switch", Icon = "bi bi-nintendo-switch" },
                new Device { Id = 4, Name = "PC", Icon = "bi bi-pc-display" }
            });


    }
}


