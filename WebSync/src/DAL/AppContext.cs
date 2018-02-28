using Microsoft.EntityFrameworkCore;
using Addon365.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addon365.WebSync.DAL
{
    public class SyncAppContext : DbContext
    {
        //Use LocalConnection for Local DB connection.
        //Use AzureConnection for Azure DB connection.
        public SyncAppContext(DbContextOptions<SyncAppContext> options) : base(options)
        {

        }


        public DbSet<Identifier> Identifiers { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<LicensedMachine> LicensedMachines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Identifier>().ToTable("Identifier");
            modelBuilder.Entity<License>().ToTable("License");
            modelBuilder.Entity<LicensedMachine>().ToTable("LicensedMachine");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Report>().ToTable("Report");

        }
    }
}
