using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SafeShopping.DataAccess.Migrations
{
    public partial class Initil2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "MyGuid",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyGuid",
                table: "Accounts");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
