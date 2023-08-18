using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReviewsApi.Models;

public partial class RestaurantReviewsDbContext : DbContext
{
    public RestaurantReviewsDbContext(DbContextOptions<RestaurantReviewsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Restaura__3214EC07ADA58F26");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Review).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
