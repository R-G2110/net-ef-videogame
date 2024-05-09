using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_SoftwareHouses_SoftwareHouseId",
                table: "videogame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareHouses",
                table: "SoftwareHouses");

            migrationBuilder.RenameTable(
                name: "SoftwareHouses",
                newName: "software_houses");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "videogame",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "videogame",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "videogame",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "software_houses",
                newName: "PIva");

            migrationBuilder.AlterColumn<string>(
                name: "release_date",
                table: "videogame",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "software_houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "software_houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_software_houses",
                table: "software_houses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_software_houses_SoftwareHouseId",
                table: "videogame",
                column: "SoftwareHouseId",
                principalTable: "software_houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_software_houses_SoftwareHouseId",
                table: "videogame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_software_houses",
                table: "software_houses");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "software_houses");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "software_houses");

            migrationBuilder.RenameTable(
                name: "software_houses",
                newName: "SoftwareHouses");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "videogame",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "videogame",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "videogame",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "PIva",
                table: "SoftwareHouses",
                newName: "TaxId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "videogame",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareHouses",
                table: "SoftwareHouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_SoftwareHouses_SoftwareHouseId",
                table: "videogame",
                column: "SoftwareHouseId",
                principalTable: "SoftwareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
