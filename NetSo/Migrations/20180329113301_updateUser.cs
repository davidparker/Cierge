using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetSo.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavColor",
                table: "AspNetUsers",
                newName: "MobileNumber");

            migrationBuilder.AddColumn<bool>(
                name: "SendCodesViaSms",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendCodesViaSms",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "AspNetUsers",
                newName: "FavColor");
        }
    }
}
