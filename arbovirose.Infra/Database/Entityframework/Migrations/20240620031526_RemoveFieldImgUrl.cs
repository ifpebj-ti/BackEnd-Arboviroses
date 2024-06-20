﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arbovirose.Infra.Database.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFieldImgUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "InfoHome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "InfoHome",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
