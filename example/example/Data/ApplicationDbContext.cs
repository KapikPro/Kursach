﻿using example.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace example.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Articles> Articles => Set<Articles>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
            .Property(x => x.Date)
            .HasDefaultValueSql("now()");

            builder.Entity<Articles>()
            .Property(x => x.Date)
            .HasDefaultValueSql("now()");

            builder.Entity<Articles>()
            .Property(x=>x.IsActive)
            .HasDefaultValue(true); 
        }
    }
}
