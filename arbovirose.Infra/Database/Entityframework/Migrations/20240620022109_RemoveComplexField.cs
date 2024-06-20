using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arbovirose.Infra.Database.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemoveComplexField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl_value",
                table: "InfoHome");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "InfoHome",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "InfoHome");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl_value",
                table: "InfoHome",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
