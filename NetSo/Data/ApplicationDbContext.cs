using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetSo.Models;
using NetSo.Data;

namespace NetSo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AuthEvent> AuthEvents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Site> Sites { get; set;  }
        public DbSet<UserSiteAssignment> UserSiteAssignments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ApplicationUser>()
            .HasIndex(nameof(ApplicationUser.Email))
            .IsUnique(false);

            builder.Entity<AuthEvent>()
                .HasOne(e => e.User)
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserSiteAssignment>()
            .HasOne(s => s.Site);

            builder.Entity<UserSiteAssignment>()
            .HasOne(x => x.Client);

            builder.Entity<UserSiteAssignment>()
            .HasOne(x => x.User);

        }

    }
}
