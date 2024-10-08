﻿using Microsoft.EntityFrameworkCore;
using SmartBookStoreRazor_Temp.Models;

namespace SmartBookStoreRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "BollyWood", DisplayOrder = 1 },
                new Category { Id = 2, Name = "HollyWood", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }


    }
}
