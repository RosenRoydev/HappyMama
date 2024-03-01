using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
                 .Property<string>("ParentId");

            builder.Entity<EventParent>()
                .HasKey(ep => new { ep.EventId, ep.ParentId });

            builder.Entity<EventParent>()
              .HasOne(ep => ep.Parent)
              .WithMany()
              .HasForeignKey(ep => ep.ParentId);

            builder.Entity<EventParent>()
             .HasOne(ep => ep.Event)
             .WithMany(e => e.Parents) 
             .HasForeignKey(ep => ep.EventId);

            base.OnModelCreating(builder);
        }

        public DbSet<EventParent> EventsParents { get; set;} 
        public DbSet<Event> Events { get; set;}
        public DbSet<Post> Posts { get; set;}
        public DbSet<News> News { get; set;}
        public DbSet<Theme> Themes { get; set;}
        public DbSet<Teacher> Teachers { get; set;}
        public DbSet<Parent> Parents { get; set;}
        public DbSet <Admin> Admins { get; set;}
    }
}
