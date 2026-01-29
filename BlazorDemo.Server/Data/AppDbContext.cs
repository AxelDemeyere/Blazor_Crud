﻿using BlazorDemo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produit> Produits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Prix).HasPrecision(10, 2);
                entity.Property(e => e.Categorie).IsRequired().HasMaxLength(50).HasConversion<string>();
                entity.Property(e => e.DateCreation).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasIndex(e => e.Categorie);
                entity.HasIndex(e => e.Nom);
            });
        }
    }
}
