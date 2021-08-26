using AppAutohouse.DAL.Contexts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCAppAutohouse.DAL.Entities;
using System;
using System.Collections.Generic;


namespace AppAutohouse.DAL.Context
{
    public class AutohouseContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Brand> Brands { get; set; } = default!;
        public AutohouseContext(DbContextOptions<AutohouseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected AutohouseContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
