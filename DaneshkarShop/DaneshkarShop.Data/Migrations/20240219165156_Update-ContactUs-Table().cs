using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaneshkarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactUsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "ContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "ContactUs");
        }
    }
}
