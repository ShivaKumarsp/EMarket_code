using EMarket.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using EMarket.Entities.Models;

namespace EMarket.Entities.DataAccess
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)

        {
            Database.SetCommandTimeout(300000);
        }


        public DbSet<Models.ApplicationUser> applicationUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var applicationUser = modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");

            applicationUser.Property(au => au.UserName).HasMaxLength(50).HasColumnName("UserName").HasColumnType("VARCHAR(4000)");

            var role = modelBuilder.Entity<ApplicationRole>().ToTable("ApplicationRole");
            var claim = modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("ApplicationUserClaim");
            var login = modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("ApplicationUserLogin");
            var userRole = modelBuilder.Entity<IdentityUserRole<int>>().ToTable("ApplicationUserRole");

            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("ApplicationRoleClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("ApplicationUserToken");

        }
    }
}
