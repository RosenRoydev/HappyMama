using HappyMama.Infrastructure.Data.DataModels;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventParent>()
                .HasKey(ep => new {ep.EventId, ep.ParentId});

            base.OnModelCreating(builder);
        }

        public DbSet<EventParent> EventsParents { get; set;} 
        public DbSet<Event> Events { get; set;}
        public DbSet<Post> Posts { get; set;}
        public DbSet<News> News { get; set;}
        public DbSet<Theme> Themes { get; set;}
    }
}
