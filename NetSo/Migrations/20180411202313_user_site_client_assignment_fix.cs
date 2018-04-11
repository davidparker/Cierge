using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetSo.Migrations
{
    public partial class user_site_client_assignment_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UUserSiteAssignments_Clients_ClientId",
                table: "UUserSiteAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UUserSiteAssignments_Sites_SiteId",
                table: "UUserSiteAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UUserSiteAssignments_AspNetUsers_UserId",
                table: "UUserSiteAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UUserSiteAssignments",
                table: "UUserSiteAssignments");

            migrationBuilder.RenameTable(
                name: "UUserSiteAssignments",
                newName: "UserSiteAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_UUserSiteAssignments_UserId",
                table: "UserSiteAssignments",
                newName: "IX_UserSiteAssignments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UUserSiteAssignments_SiteId",
                table: "UserSiteAssignments",
                newName: "IX_UserSiteAssignments_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_UUserSiteAssignments_ClientId",
                table: "UserSiteAssignments",
                newName: "IX_UserSiteAssignments_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSiteAssignments",
                table: "UserSiteAssignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSiteAssignments_Clients_ClientId",
                table: "UserSiteAssignments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSiteAssignments_Sites_SiteId",
                table: "UserSiteAssignments",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSiteAssignments_AspNetUsers_UserId",
                table: "UserSiteAssignments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSiteAssignments_Clients_ClientId",
                table: "UserSiteAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSiteAssignments_Sites_SiteId",
                table: "UserSiteAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSiteAssignments_AspNetUsers_UserId",
                table: "UserSiteAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSiteAssignments",
                table: "UserSiteAssignments");

            migrationBuilder.RenameTable(
                name: "UserSiteAssignments",
                newName: "UUserSiteAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_UserSiteAssignments_UserId",
                table: "UUserSiteAssignments",
                newName: "IX_UUserSiteAssignments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSiteAssignments_SiteId",
                table: "UUserSiteAssignments",
                newName: "IX_UUserSiteAssignments_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSiteAssignments_ClientId",
                table: "UUserSiteAssignments",
                newName: "IX_UUserSiteAssignments_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UUserSiteAssignments",
                table: "UUserSiteAssignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UUserSiteAssignments_Clients_ClientId",
                table: "UUserSiteAssignments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UUserSiteAssignments_Sites_SiteId",
                table: "UUserSiteAssignments",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UUserSiteAssignments_AspNetUsers_UserId",
                table: "UUserSiteAssignments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
