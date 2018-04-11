using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetSo.Migrations
{
    public partial class user_site_client_assignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UUserSiteAssignments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    SiteId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UUserSiteAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UUserSiteAssignments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UUserSiteAssignments_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UUserSiteAssignments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UUserSiteAssignments_ClientId",
                table: "UUserSiteAssignments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UUserSiteAssignments_SiteId",
                table: "UUserSiteAssignments",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_UUserSiteAssignments_UserId",
                table: "UUserSiteAssignments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UUserSiteAssignments");
        }
    }
}
