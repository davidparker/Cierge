using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetSo.Migrations
{
    public partial class add_more_props_to_Sites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasClients",
                table: "Sites",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HostName",
                table: "Sites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasClients",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "HostName",
                table: "Sites");
        }
    }
}
