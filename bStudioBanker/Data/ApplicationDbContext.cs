using BSSL.ObjectModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bStudioBanker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Customers> Customers { get; set; }
        
        public DbSet<AccountTypes> AccountTypes { get; set; }

        public DbSet<AccountsTransactions> AccountsTransactions { get; set; }
    }
}
