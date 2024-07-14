using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arbovirose.Infra.Database.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeInfoField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeInfo_Value",
                table: "InfoHome",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeInfo_Value",
                table: "InfoHome");
        }
    }
}
