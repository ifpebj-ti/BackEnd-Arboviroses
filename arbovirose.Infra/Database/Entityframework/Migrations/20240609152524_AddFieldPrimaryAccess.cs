using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arbovirose.Infra.Database.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldPrimaryAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrimaryAccess",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryAccess",
                table: "Users");
        }
    }
}
