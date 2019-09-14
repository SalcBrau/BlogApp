using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
            .HasAnnotation("Relational:MaxIdentifierLength", 128)
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property<string>("Description");

                entity.Property<string>("UrlSlug");

                entity.HasKey("Id");

                entity.ToTable("Categories");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                entity.Property<int>("CategoryId");

                entity.Property<string>("Description");

                entity.Property<string>("Meta");

                entity.Property<DateTime>("Modified");

                entity.Property<DateTime>("PostedOn");

                entity.Property<bool>("Published");

                entity.Property<string>("ShortDescription");

                entity.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property<string>("UrlSlug");

                entity.HasKey("Id");

                entity.HasIndex("CategoryId");

                entity.ToTable("Posts");

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Posts)
                    .HasForeignKey(p => p.CategoryId)
                    .HasConstraintName("FK_Post_Categories_CategoryId")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.Property<int>("PostId");

                entity.Property<int>("TagId");

                entity.HasKey(pt => new { pt.PostId, pt.TagId });

                entity.ToTable("PostTags");

                entity.HasOne(pt => pt.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(pt => pt.PostId)
                    .HasConstraintName("FK_PostTag_Posts_PostId")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pt => pt.Tag)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(pt => pt.TagId)
                    .HasConstraintName("FK_PostTag_Tags_TagId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }        
    }
}
