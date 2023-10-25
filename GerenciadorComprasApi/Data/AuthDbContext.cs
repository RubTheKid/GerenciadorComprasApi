using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorComprasApi.Data;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        var SuperAdminRoleId = "187cd807-b7d4-4d42-9f4a-85b01d3aa4a6";
        var AdminRoleId = "642da2b8-7ec9-4e85-978a-a935ea187c3a";
        var UserRoleId = "5fb90452-843a-4a57-b35b-42c35292a2a6";

        var roles = new List<IdentityRole>
        {
          new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = SuperAdminRoleId,
                ConcurrencyStamp = SuperAdminRoleId
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = AdminRoleId,
                ConcurrencyStamp = AdminRoleId
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "User",
                Id = UserRoleId,
                ConcurrencyStamp = UserRoleId
            }
        };

        mb.Entity<IdentityRole>().HasData(roles);

        var superAdminId = "30280c3d-1370-4704-9f5e-563f0375c173";
        var superAdminUser = new IdentityUser
        {
            UserName = "superadmin@gerenciador.com",
            Email = "superadmin@gerenciador.com",
            NormalizedEmail = "superadmin@gerenciador.com".ToUpper(),
            NormalizedUserName = "superadmin@gerenciador.com".ToUpper(),
            Id = superAdminId
        };

        superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
            .HashPassword(superAdminUser, "superadmin123");

        mb.Entity<IdentityUser>().HasData(superAdminUser);


        //todos os papeis para o superadmin
        var superAdminRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = SuperAdminRoleId,
                UserId = superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = UserRoleId,
                UserId = superAdminId
            }
        };

        mb.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

    }
}
