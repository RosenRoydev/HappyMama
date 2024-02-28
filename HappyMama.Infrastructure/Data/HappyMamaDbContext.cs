using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HappyMama.Infrastructure.Data
{
    public class HappyMamaDbContext : IdentityDbContext
    {
        public HappyMamaDbContext(DbContextOptions<HappyMamaDbContext> options)
            : base(options)
        {
        }
    }
}
