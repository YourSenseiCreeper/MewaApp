using MewaAppBackend.Model.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Model.Model.File> File { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<DbImage> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Avatar)
                .WithOne(f => f.User)
                .HasForeignKey<Model.Model.File>(f => f.UserId);

            modelBuilder.Entity<Link>()
                .Property("CreationDate")
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Link>()
                .HasOne(u => u.Thumbnail)
                .WithOne(i => i.Link)
                .HasForeignKey<DbImage>(i => i.LinkId);
        }
    }
}
