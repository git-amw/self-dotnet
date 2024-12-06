using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AccData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.AccountId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccData_UserId",
                table: "AccData",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccData_User_UserId",
                table: "AccData",
                column: "UserId",
                principalTable: "User",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccData_User_UserId",
                table: "AccData");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_AccData_UserId",
                table: "AccData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccData");
        }
    }
}
