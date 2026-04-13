using blog.Entities.Blog;
using blog.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;

namespace blog.Entities
{
    public class BlogContext(DbContextOptions<BlogContext> options) : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.UserName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Password).HasMaxLength(60).IsRequired();
                entity.Property(x => x.LogInDate).HasDefaultValue("GETDATE()");
                entity.Property(x => x.CreateDate).HasDefaultValue("GETDATE()");
            });

            builder.Entity<Posts>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Content).IsRequired();
                entity.Property(x => x.CreateDate).HasDefaultValue("GETDATE()");

                entity.HasOne(e => e.User).WithMany(e => e.Posts).HasForeignKey(e => e.CreateUser).HasPrincipalKey(e => e.Id);
            });
        }
    }
}
