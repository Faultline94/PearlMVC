using Microsoft.EntityFrameworkCore;

namespace PearlMVC.Data
{
    public class PearlMVCContext : DbContext
    {
        public PearlMVCContext(DbContextOptions<PearlMVCContext> options)
            : base(options)
        {
        }

        public DbSet<PearlNecklace.Necklace> Necklace { get; set; }
    }
}
