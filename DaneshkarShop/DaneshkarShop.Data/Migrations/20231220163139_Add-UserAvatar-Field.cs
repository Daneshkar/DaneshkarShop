using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaneshkarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAvatarField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAvatar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAvatar",
                table: "Users");
        }
    }
}
