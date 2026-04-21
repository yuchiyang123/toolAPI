using blog.Entities.Blog;
using blog.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;

namespace blog.Entities
{
    public class BlogContext(DbContextOptions<BlogContext> options) : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<PostsChangeRecord> PostsChangeRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.UserName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Password).HasMaxLength(60).IsRequired();
                entity.Property(x => x.LogInDate).HasDefaultValueSql("GETDATE()");
                entity.Property(x => x.CreateDate).HasDefaultValueSql("GETDATE()");
            });

            builder.Entity<Posts>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Content).IsRequired();
                entity.Property(x => x.CreateDate).HasDefaultValueSql("GETDATE()");
                entity.Property(x => x.View).HasDefaultValue(0).IsRequired();

                entity.HasOne(e => e.User).WithMany(e => e.Posts).HasForeignKey(e => e.CreateUserId).HasPrincipalKey(e => e.Id);
            });

            builder.Entity<PostsChangeRecord>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.CreateDate).HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Users).WithMany(e => e.PostsChangeRecords).HasForeignKey(e => e.CreateUserId).HasPrincipalKey(e => e.Id);
                entity.HasOne(e => e.Posts).WithMany(e => e.PostsChangeRecords).HasForeignKey(e => e.FK_PostsId).HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
