using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MessageConsumer.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AccountDetails> AccountTable { get; set; }
    }
    public class AccountDetails
    {  
        [Key]
        public int Id { get; set; }
        public int AcccountNumber { get; set; }
    }
}
