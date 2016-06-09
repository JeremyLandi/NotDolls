using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NotDolls.Migrations
{
    public partial class TableNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Geek",
                columns: table => new
                {
                    GeekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geek", x => x.GeekId);
                });

            migrationBuilder.AddColumn<int>(
                name: "GeekId",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeekId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Geek");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);
        }
    }
}
