using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareMyPaper.Infraestructure.Migrations
{
    public partial class CustomLengthToPostText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                  name: "Text",
                  table: "Post");
            migrationBuilder.AddColumn<string>(
                  name: "Text",
                  table: "Post",
                  type: "nvarchar(800)",
                  maxLength: 800,
                  nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "343875e6-8027-4a24-a0fe-51937071e50f", "AQAAAAEAACcQAAAAEEFzTE8UA5Vzn7vfD0c141yaeHC2w+gQImPtd8tWMKVgcs+9ooEk79CpL72Cm8TfAA==", "a0a27638-96c7-479e-82f7-27e0704ee6f6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5dab8e9-4c86-4056-98e4-1af3630b0494", "AQAAAAEAACcQAAAAELc3VtTH2VxhcIN8PEalSVOvlb2gbnfwYkMA3cS7wyrSS/YNp1KGoPvL8s5SJQAZ1g==", "78a38f2b-7c78-4f88-83eb-1548e37896d8" });
            migrationBuilder.DropColumn(
               name: "Text",
               table: "Post");
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Post",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
