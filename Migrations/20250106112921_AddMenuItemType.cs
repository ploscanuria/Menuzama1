using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menuzama1.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuItemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuItemTypeID",
                table: "MenuItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuItemType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuItemTypeID",
                table: "MenuItem",
                column: "MenuItemTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_MenuItemType_MenuItemTypeID",
                table: "MenuItem",
                column: "MenuItemTypeID",
                principalTable: "MenuItemType",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_MenuItemType_MenuItemTypeID",
                table: "MenuItem");

            migrationBuilder.DropTable(
                name: "MenuItemType");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuItemTypeID",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "MenuItemTypeID",
                table: "MenuItem");
        }
    }
}
