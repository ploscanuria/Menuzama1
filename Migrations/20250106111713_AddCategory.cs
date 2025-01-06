using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menuzama1.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "MenuItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_CategoryID",
                table: "MenuItem",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Category_CategoryID",
                table: "MenuItem",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Category_CategoryID",
                table: "MenuItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_CategoryID",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "MenuItem");
        }
    }
}
