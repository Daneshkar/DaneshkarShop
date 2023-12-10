using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaneshkarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSuperAdminFieldToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SuperAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuperAdmin",
                table: "Users");
        }
    }
}
