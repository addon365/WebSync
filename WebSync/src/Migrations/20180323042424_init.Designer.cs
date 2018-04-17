﻿// <auto-generated />
using Addon365.WebSync.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Addon365.WebSync.Migrations
{
    [DbContext(typeof(SyncAppContext))]
    [Migration("20180323042424_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Addon365.Models.Identifier", b =>
                {
                    b.Property<Guid>("IdentifierId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorizedGMail");

                    b.Property<string>("CustomId");

                    b.Property<string>("MobileNumer");

                    b.Property<string>("Name");

                    b.HasKey("IdentifierId");

                    b.ToTable("Identifier");
                });

            modelBuilder.Entity("Addon365.Models.License", b =>
                {
                    b.Property<Guid>("LicenseId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivatedDate");

                    b.Property<string>("CustomId");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<Guid?>("IdentifierId");

                    b.Property<DateTime>("InActiveDate");

                    b.Property<Guid?>("ProductId");

                    b.HasKey("LicenseId");

                    b.HasIndex("IdentifierId");

                    b.HasIndex("ProductId");

                    b.ToTable("License");
                });

            modelBuilder.Entity("Addon365.Models.LicensedMachine", b =>
                {
                    b.Property<Guid>("LicensedMachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomId");

                    b.Property<string>("DeviceId");

                    b.Property<Guid?>("LicenseId");

                    b.HasKey("LicensedMachineId");

                    b.HasIndex("LicenseId");

                    b.ToTable("LicensedMachine");
                });

            modelBuilder.Entity("Addon365.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomId");

                    b.Property<string>("Name");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Addon365.Models.Report", b =>
                {
                    b.Property<Guid>("ReportId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomId");

                    b.Property<DateTime>("Date");

                    b.Property<Guid?>("LicenseId");

                    b.Property<decimal>("TotalAmount");

                    b.HasKey("ReportId");

                    b.HasIndex("LicenseId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("Addon365.Models.License", b =>
                {
                    b.HasOne("Addon365.Models.Identifier", "Identifier")
                        .WithMany()
                        .HasForeignKey("IdentifierId");

                    b.HasOne("Addon365.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Addon365.Models.LicensedMachine", b =>
                {
                    b.HasOne("Addon365.Models.License", "License")
                        .WithMany()
                        .HasForeignKey("LicenseId");
                });

            modelBuilder.Entity("Addon365.Models.Report", b =>
                {
                    b.HasOne("Addon365.Models.License", "License")
                        .WithMany()
                        .HasForeignKey("LicenseId");
                });
#pragma warning restore 612, 618
        }
    }
}
