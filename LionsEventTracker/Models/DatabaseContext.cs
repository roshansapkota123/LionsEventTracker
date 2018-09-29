using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LionsEventTracker.Models
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventUser> EventUser { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EventUser>()
                .HasKey(t => new { t.userId, t.eventId });

            builder.Entity<EventUser>()
                .HasOne(u => u.Events)
                .WithMany(e => e.eventUser)
                .HasForeignKey(f => f.eventId);

            builder.Entity<EventUser>()
               .HasOne(u => u.Users)
               .WithMany(e => e.eventUser)
               .HasForeignKey(f => f.userId);
        }
    }
}
