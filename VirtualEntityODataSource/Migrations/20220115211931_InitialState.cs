using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualEntityODataSource.Migrations
{
    public partial class InitialState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrivingLicenceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingLicenceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonimmigrantVisaCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurposeOfTravel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeApplyingForVisa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonimmigrantVisaCategories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrivingLicenceTypes");

            migrationBuilder.DropTable(
                name: "NonimmigrantVisaCategories");
        }
    }
}
