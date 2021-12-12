using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareMyPaper.Infraestructure.Migrations
{
    public partial class addIsPublicFlagOnPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Post",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Post",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb3e7b8-a8c1-445f-9293-c0ee946072ae", "AQAAAAEAACcQAAAAEOTw10iv1BaNQ84Op6U5d6ItXtFVQhX3wV5ImEtIV/Kx2yjmMzblDRSN03WURti2bA==", "1d9c72e3-412f-474c-b377-60b0faac5996" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Post");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e17ac01a-91cb-4c5e-9e6d-ee9857bff163", "AQAAAAEAACcQAAAAEEPuzLIaQ9juxkS9/m7nLjzfTK1EAYTwvBOwWyTTB6QDFsgfT1AKYOP8ZcEvkTGqqA==", "c6be0985-33a9-41dd-9ae5-d0e9f7ebebe4" });
        }
    }
}
