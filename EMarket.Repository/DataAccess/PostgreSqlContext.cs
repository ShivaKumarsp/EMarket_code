
using EMarket.Data;
using EMarket.Entities;
using EMarket.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace EMarket.Repository
{

    public class PostgreSqlContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options)
        {
        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<IdentityRole> IdentityRole { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Master_LocationDMO> Master_Location_con { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserRole<string>>().ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("ApplicationUserLogins");
            builder.Entity<IdentityUserClaim<string>>().ToTable("ApplicationUserClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("ApplicationUserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("ApplicationRoleClaims");

           
        }

       

        public virtual async Task<long> SaveChangeAsync()
        {
            ChangeTracker.DetectChanges();
            return await base.SaveChangesAsync();
        }

    }
}
