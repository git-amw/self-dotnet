using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi5.Data;

namespace webapi5
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> User { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           builder.HasSequence<int>("AccNumber").StartsAt(3000).IncrementsBy(1);

            builder.Entity<ApplicationUser>()
                .Property(o => o.AccNumber)
            .HasDefaultValueSql("NEXT VALUE FOR AccNumber");

        }
    }
}
