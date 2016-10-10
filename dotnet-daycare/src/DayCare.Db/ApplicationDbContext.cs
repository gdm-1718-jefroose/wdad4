using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OpenIddict;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using DayCare.Models;
using DayCare.Models.Security;

namespace DayCare.Db
{
    public class ApplicationDbContext : OpenIddictDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("uuid-ossp");

            base.OnModelCreating(builder);

            // Organisation Model Mapping
            builder.Entity<Organisation>()
                .HasKey(o => o.Id);

            builder.Entity<Organisation>()
                .Property(o => o.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<Organisation>()
                .Property(o => o.Description)
                .HasMaxLength(511)
                .IsRequired();

            builder.Entity<Organisation>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder.Entity<Organisation>()
                .Property(o => o.UpdatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate();

            // Location Model Mapping
            builder.Entity<Location>()
                .HasKey(o => o.Id);

            builder.Entity<Location>()
                .Property(o => o.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<Location>()
                .Property(o => o.Description)
                .HasMaxLength(511)
                .IsRequired();

            builder.Entity<Location>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder.Entity<Location>()
                .Property(o => o.UpdatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate();

            // Relationship between location and organisation: 0 to many (n)
            builder.Entity<Location>()
                .HasOne(l => l.Organisation)
                .WithMany(o => o.Locations)
                .HasForeignKey(l => l.OrganisationId);

            // Group Model Mapping
            builder.Entity<Group>()
                .HasKey(o => o.Id);

            builder.Entity<Group>()
                .Property(o => o.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<Group>()
                .Property(o => o.Description)
                .HasMaxLength(511)
                .IsRequired();

            builder.Entity<Group>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder.Entity<Group>()
                .Property(o => o.UpdatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate();

            // Relationship between group and location: 0 to many (n)
            builder.Entity<Group>()
                .HasOne(g => g.Location)
                .WithMany(l => l.Groups)
                .HasForeignKey(g => g.LocationId);

            // Post Model Mapping
            builder.Entity<Post>()
                .HasKey(o => o.Id);

            builder.Entity<Post>()
                .Property(o => o.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<Post>()
                .Property(o => o.Description)
                .HasMaxLength(511)
                .IsRequired();

            builder.Entity<Post>()
                .Property(o => o.Body)
                .IsRequired();

            builder.Entity<Post>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder.Entity<Post>()
                .Property(o => o.UpdatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate();

            builder.Entity<Post>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);

            // Category Model Mapping
            builder.Entity<Category>()
                .HasKey(o => o.Id);

            builder.Entity<Category>()
                .Property(o => o.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<Category>()
                .Property(o => o.Description)
                .HasMaxLength(511)
                .IsRequired();

            builder.Entity<Category>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder.Entity<Category>()
                .Property(o => o.UpdatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate(); 

            builder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(p => p.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId);

            // Tag Model Mapping
            builder.Entity<Tag>()
                .HasKey(o => o.Id);

            builder.Entity<Tag>()
                .Property(o => o.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<Tag>()
                .Property(o => o.Description)
                .HasMaxLength(511)
                .IsRequired();

            builder.Entity<Tag>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder.Entity<Tag>()
                .Property(o => o.UpdatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate();

            // Many-To-Many in EF7 (10-10-2016)
            // Post can have many tags
            // Tag can be assigned to many posts
            builder.Entity<PostTag>()
                .HasKey(t => new { t.PostId, t.TagId });

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.PostId);

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(p => p.Posts)
                .HasForeignKey(pt => pt.TagId);

            // ActivityType Model Mapping
            builder.Entity<ActivityType>()
                .HasKey(o => o.Id);

            builder.Entity<ActivityType>()
                .Property(o => o.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<ActivityType>()
                .Property(o => o.Description)
                .HasMaxLength(511)
                .IsRequired();

            builder.Entity<ActivityType>()
                .Property(o => o.ThumbnailURL)
                .IsRequired();

            builder.Entity<ActivityType>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder.Entity<ActivityType>()
                .Property(o => o.UpdatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate(); 

            builder.Entity<ActivityType>()
                .HasOne(c => c.ParentActivityType)
                .WithMany(p => p.ChildActivityTypes)
                .HasForeignKey(c => c.ParentActivityTypeId);
        }
    }
}
