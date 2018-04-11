using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cierge.Migrations
{
    public partial class updateuserclientsite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "clientName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sites",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sites_ApplicationUserId",
                table: "Sites",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ApplicationUserId",
                table: "Clients",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId",
                table: "Clients",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_AspNetUsers_ApplicationUserId",
                table: "Sites",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_AspNetUsers_ApplicationUserId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Sites_ApplicationUserId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ApplicationUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "clientName",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
