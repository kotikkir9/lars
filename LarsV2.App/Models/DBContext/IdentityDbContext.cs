using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LarsV2.Models.DBContext
{
    public class IdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsers(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            string ADMIN_ID = "3bb4b222-f47e-43fa-9d9e-66989c3aa296";
            string PASSWORD = "Password";
            string ADMIN_ROLE_ID = "30aefd55-811c-4d45-9783-39cb7015e76b";
            string ADMIN_ROLE = "Admin";

            IdentityRole role = new IdentityRole()
            {
                Id = ADMIN_ROLE_ID,
                Name = ADMIN_ROLE,
                NormalizedName = ADMIN_ROLE.ToUpper()
            };

            IdentityUser user = new IdentityUser()
            {
                Id = ADMIN_ID,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = false
            };

            IdentityUserRole<string> userRole = new IdentityUserRole<string>()
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            };


            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            var hashedPassword = passwordHasher.HashPassword(user, PASSWORD);

            user.PasswordHash = hashedPassword;

            builder.Entity<IdentityRole>().HasData(role);
            builder.Entity<IdentityUser>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
    }
}
