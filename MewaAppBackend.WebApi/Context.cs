using MewaAppBackend.Model.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Model.Model.File> File { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.File)
                .WithOne(f => f.User)
                .HasForeignKey<Model.Model.File>(f => f.UserId);
        }
    }
}
