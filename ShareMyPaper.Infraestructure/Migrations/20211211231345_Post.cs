using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareMyPaper.Infraestructure.Migrations
{
    public partial class Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DocumentId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KnowledgeAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_KnowledgeArea_KnowledgeAreaId",
                        column: x => x.KnowledgeAreaId,
                        principalTable: "KnowledgeArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e17ac01a-91cb-4c5e-9e6d-ee9857bff163", "AQAAAAEAACcQAAAAEEPuzLIaQ9juxkS9/m7nLjzfTK1EAYTwvBOwWyTTB6QDFsgfT1AKYOP8ZcEvkTGqqA==", "c6be0985-33a9-41dd-9ae5-d0e9f7ebebe4" });

            migrationBuilder.CreateIndex(
                name: "IX_Post_KnowledgeAreaId",
                table: "Post",
                column: "KnowledgeAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f03601e-4650-4d79-b069-a74dc3ae33f2", "AQAAAAEAACcQAAAAEKbt0lj9xoUk/GftVq9xZx6bDiRStrAxScYCCo5o9tpndcQTg2QvfSJxZib0FxkiDg==", "bf37e55b-14bb-4c63-9dd4-e668dcb141ba" });
        }
    }
}
