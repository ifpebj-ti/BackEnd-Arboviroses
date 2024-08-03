using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arbovirose.Infra.Database.Entityframework.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoHome",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Topic = table.Column<string>(type: "varchar(50)", nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    TitleLink = table.Column<string>(type: "varchar(100)", nullable: true),
                    Link = table.Column<string>(type: "varchar(100)", nullable: false),
                    TypeInfo_Value = table.Column<string>(type: "varchar(10)", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoHome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Office_value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    PrimaryAccess = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProfileId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email_value = table.Column<string>(type: "TEXT", nullable: false),
                    UniqueCode_value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoHome");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
