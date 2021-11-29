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

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            var hashedPassword = passwordHasher.HashPassword(user, PASSWORD);

            user.PasswordHash = hashedPassword;

            builder.Entity<IdentityUser>().HasData(user);
        }
    }
}
