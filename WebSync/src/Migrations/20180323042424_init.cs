using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Addon365.WebSync.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Identifier",
                columns: table => new
                {
                    IdentifierId = table.Column<Guid>(nullable: false),
                    AuthorizedGMail = table.Column<string>(nullable: true),
                    CustomId = table.Column<string>(nullable: true),
                    MobileNumer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifier", x => x.IdentifierId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CustomId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    LicenseId = table.Column<Guid>(nullable: false),
                    ActivatedDate = table.Column<DateTime>(nullable: false),
                    CustomId = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IdentifierId = table.Column<Guid>(nullable: true),
                    InActiveDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.LicenseId);
                    table.ForeignKey(
                        name: "FK_License_Identifier_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifier",
                        principalColumn: "IdentifierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_License_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicensedMachine",
                columns: table => new
                {
                    LicensedMachineId = table.Column<Guid>(nullable: false),
                    CustomId = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    LicenseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensedMachine", x => x.LicensedMachineId);
                    table.ForeignKey(
                        name: "FK_LicensedMachine_License_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "License",
                        principalColumn: "LicenseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(nullable: false),
                    CustomId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    LicenseId = table.Column<Guid>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Report_License_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "License",
                        principalColumn: "LicenseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_License_IdentifierId",
                table: "License",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_License_ProductId",
                table: "License",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LicensedMachine_LicenseId",
                table: "LicensedMachine",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_LicenseId",
                table: "Report",
                column: "LicenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicensedMachine");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Identifier");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
