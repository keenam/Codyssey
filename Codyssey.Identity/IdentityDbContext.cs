using Microsoft.EntityFrameworkCore;

namespace Codyssey.Identity
{
    /// <summary>
    /// EntityFramework database context
    /// </summary>
    public class IdentityDbContext : DbContext
    {
        public DbSet<Identity> Identity { get; set; }

        public IdentityDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
