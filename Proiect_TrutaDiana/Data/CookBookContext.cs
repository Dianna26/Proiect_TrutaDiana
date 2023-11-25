using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_TrutaDiana.Models;

    public class CookBookContext : DbContext
    {
        public CookBookContext (DbContextOptions<CookBookContext> options)
            : base(options)
        {
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasOne(a => a.NutritionalValues)
            .WithOne(a => a.Recipe)
            .HasForeignKey<NutritionalValues>(c => c.RecipeID);

        modelBuilder.Entity<NutritionalValues>()
            .HasOne(a => a.Recipe)
            .WithOne(a => a.NutritionalValues)
            .HasForeignKey<Recipe>(c => c.NutritionalValuesID);
    }
    public DbSet<Recipe> Recipes { get; set; } = default!;
        public DbSet<Difficulty> Difficulties { get; set; } = default!;
        public DbSet<Ingredient> Ingredients { get; set; } = default!;
        public DbSet<NutritionalValues> NutritionalValues { get; set; } = default!;
        

    }
