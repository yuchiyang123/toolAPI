using blog.Entities.Blog;
using blog.Entities.Recipes;
using blog.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace blog.Entities
{
    public class BlogContext(DbContextOptions<BlogContext> options) : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<PostsChangeRecord> PostsChangeRecords { get; set; }
        public DbSet<PostsTagMapping> PostsTagsMapping { get; set; }
        public DbSet<PostsTag> PostsTags { get; set; }
        public DbSet<Files> Files { get; set; }

        #region 食譜
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }
        public DbSet<RecipeDetailMapping> RecipeDetailsMapping { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public DbSet<RecipeIngredientsMapping> RecipeIngredientsMappings { get; set; }
        public DbSet<RecipeIngredientsDetail> RecipeIngredientsDetails { get; set; }
        public DbSet<RecipeIngredientsDetailMapping> RecipeIngredientsDetailMappings { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<RecipeStepMapping> RecipeStepMappings { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<RecipeTagMapping> RecipeTagMappings { get; set; }
        public DbSet<RecipeFileMapping> RecipeFileMappings { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.UserName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.PasswordHash).HasMaxLength(256).IsRequired();
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

                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.Posts)
                    .HasForeignKey(e => e.CreateUserId)
                    .HasPrincipalKey(e => e.Id);
            });

            builder.Entity<PostsChangeRecord>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.CreateDate).HasDefaultValueSql("GETDATE()");

                entity
                    .HasOne(e => e.Users)
                    .WithMany(e => e.PostsChangeRecords)
                    .HasForeignKey(e => e.CreateUserId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.NoAction);
                entity
                    .HasOne(e => e.Posts)
                    .WithMany(e => e.PostsChangeRecords)
                    .HasForeignKey(e => e.FK_PostsId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PostsTagMapping>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(e => e.Posts)
                    .WithMany(e => e.PostsTagsMapping)
                    .HasForeignKey(e => e.FK_PostsId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(e => e.PostsTag)
                    .WithMany(e => e.PostsTagMapping)
                    .HasForeignKey(e => e.FK_TagId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PostsTag>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Tag).HasMaxLength(50).IsRequired();
                entity.Property(x => x.CreateDate).HasDefaultValueSql("GETDATE()");
            });

            builder.Entity<Files>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FileName).IsRequired();
                entity.Property(x => x.Path).IsRequired();
                entity.Property(x => x.CreateDate).HasDefaultValueSql("GETDATE()");
            });

            #region 食譜
            builder.Entity<Recipe>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RecipeName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Amount).IsRequired();
                entity.Property(x => x.CookingTime).IsRequired();
                entity.Property(x => x.Complexity).IsRequired();
                entity.Property(x => x.Description).HasMaxLength(500);
                entity.Property(x => x.UpdateDate).HasDefaultValueSql("GETDATE()");
                entity.Property(x => x.CreateDate).HasDefaultValueSql("GETDATE()");
            });

            builder.Entity<RecipeDetail>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Content).IsRequired();
            });

            builder.Entity<RecipeDetailMapping>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RecipeId).IsRequired();
                entity.Property(x => x.RecipeDetailId).IsRequired();

                entity
                    .HasOne(e => e.Recipe)
                    .WithOne(e => e.RecipeDetailMappings)
                    .HasForeignKey<RecipeDetailMapping>(e => e.RecipeId)
                    .HasPrincipalKey<Recipe>(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<RecipeIngredients>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.IngredientsGroupName).HasMaxLength(200).IsRequired();
            });

            builder.Entity<RecipeIngredientsMapping>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RecipeId).IsRequired();
                entity.Property(x => x.RecipeIngredientsId).IsRequired();

                entity
                    .HasOne(e => e.Recipe)
                    .WithMany(e => e.RecipeIngredientsMappings)
                    .HasForeignKey(e => e.RecipeId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(e => e.RecipeIngredients)
                    .WithMany(e => e.RecipeIngredientsMappings)
                    .HasForeignKey(e => e.RecipeIngredientsId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<RecipeIngredientsDetail>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.IngredientsName).HasMaxLength(50).IsRequired();
                entity.Property(x => x.Amount).HasMaxLength(20).IsRequired();
            });

            builder.Entity<RecipeIngredientsDetailMapping>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RecipeIngredientId).IsRequired();
                entity.Property(x => x.RecipeIngredientDetailId).IsRequired();

                entity
                    .HasOne(e => e.RecipeIngredient)
                    .WithMany(e => e.RecipeIngredientsDetailMappings)
                    .HasForeignKey(e => e.RecipeIngredientId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(e => e.RecipeIngredientsDetail)
                    .WithMany(e => e.RecipeIngredientsDetailMappings)
                    .HasForeignKey(e => e.RecipeIngredientDetailId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<RecipeStep>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Step).IsRequired();
                entity.Property(x => x.Description).HasMaxLength(1500).IsRequired();
            });

            builder.Entity<RecipeStepMapping>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RecipeId).IsRequired();
                entity.Property(x => x.RecipeStepId).IsRequired();

                entity
                    .HasOne(e => e.RecipeStep)
                    .WithMany(e => e.RecipeStepMappings)
                    .HasForeignKey(e => e.RecipeStepId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(e => e.Recipe)
                    .WithMany(e => e.RecipeStepMappings)
                    .HasForeignKey(e => e.RecipeId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<RecipeTag>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Tag).HasMaxLength(50).IsRequired();
            });

            builder.Entity<RecipeTagMapping>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RecipeId).IsRequired();
                entity.Property(x => x.RecipeTagId).IsRequired();

                entity
                    .HasOne(e => e.RecipeTag)
                    .WithMany(e => e.RecipeTagMappings)
                    .HasForeignKey(e => e.RecipeTagId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(e => e.Recipe)
                    .WithMany(e => e.RecipeTagMappings)
                    .HasForeignKey(e => e.RecipeId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<RecipeFileMapping>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RecipeId).IsRequired();
                entity.Property(x => x.FileId).IsRequired();

                entity
                    .HasOne(e => e.Recipe)
                    .WithOne(e => e.RecipeFileMappings)
                    .HasForeignKey<RecipeFileMapping>(e => e.RecipeId)
                    .HasPrincipalKey<Recipe>(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(e => e.Files)
                    .WithOne(e => e.RecipeFileMapping)
                    .HasForeignKey<RecipeFileMapping>(e => e.FileId)
                    .HasPrincipalKey<Files>(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
        }
    }
}
