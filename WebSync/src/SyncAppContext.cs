using Microsoft.EntityFrameworkCore;
using Addon365.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addon365.Models.Leads;
using Addon365.WebSync.ViewModels;

namespace Addon365.WebSync.DAL
{
    public class SyncAppContext : DbContext
    {
        //Use LocalConnection for Local DB connection.
        //Use AzureConnection for Azure DB connection.
        public SyncAppContext(DbContextOptions<SyncAppContext> options) : base(options)
        {

        }


        public DbSet<Profile> Identifiers { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<LicensedMachine> LicensedMachines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadSource> LeadSources { get; set; }
        public DbSet<LeadStatus> LeadStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Profile>().ToTable("Identifier");
            //modelBuilder.Entity<License>().ToTable("License");
            //modelBuilder.Entity<LicensedMachine>().ToTable("LicensedMachine");
            //modelBuilder.Entity<Product>().ToTable("Product");
            //modelBuilder.Entity<Report>().ToTable("Report");
            modelBuilder.Entity<Profile>()
                .HasIndex(e => e.MobileNumber)
                .IsUnique(true);
        }
    }
}



