using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareMyPaper.Infraestructure.Migrations
{
    public partial class addStudentToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Post",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be78f547-2fda-4026-a4e8-3a55ed3b38ef", "AQAAAAEAACcQAAAAEB/kao1opCZsKQcaeq9h+r/+QV1iGGOlMpH2f8l4k8yxNqcrjUKxbh9GgPMDLJzjYA==", "27ae46d0-f15b-4c81-8608-d961522dd027" });

            migrationBuilder.CreateIndex(
                name: "IX_Post_ApplicationUserId",
                table: "Post",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_ApplicationUserId",
                table: "Post",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Post");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb3e7b8-a8c1-445f-9293-c0ee946072ae", "AQAAAAEAACcQAAAAEOTw10iv1BaNQ84Op6U5d6ItXtFVQhX3wV5ImEtIV/Kx2yjmMzblDRSN03WURti2bA==", "1d9c72e3-412f-474c-b377-60b0faac5996" });
        }
    }
}
