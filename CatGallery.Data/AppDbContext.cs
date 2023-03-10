using Microsoft.EntityFrameworkCore;
using CatGallery.Data.Models;

namespace CatGallery.Data;

[Coalesce]
public class AppDbContext : DbContext
{
    public DbSet<Photo> Photos => Set<Photo>();
    public DbSet<PhotoTag> PhotoTags => Set<PhotoTag>();
    public DbSet<Tag> Tags => Set<Tag>();

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
