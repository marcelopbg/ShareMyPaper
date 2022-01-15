using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareMyPaper.Infraestructure.Migrations
{
    public partial class AddExtensionColumnToPostsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentExtension",
                table: "Post",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5dab8e9-4c86-4056-98e4-1af3630b0494", "AQAAAAEAACcQAAAAELc3VtTH2VxhcIN8PEalSVOvlb2gbnfwYkMA3cS7wyrSS/YNp1KGoPvL8s5SJQAZ1g==", "78a38f2b-7c78-4f88-83eb-1548e37896d8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentExtension",
                table: "Post");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be78f547-2fda-4026-a4e8-3a55ed3b38ef", "AQAAAAEAACcQAAAAEB/kao1opCZsKQcaeq9h+r/+QV1iGGOlMpH2f8l4k8yxNqcrjUKxbh9GgPMDLJzjYA==", "27ae46d0-f15b-4c81-8608-d961522dd027" });
        }
    }
}
