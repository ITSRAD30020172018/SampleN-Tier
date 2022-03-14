using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModel.Migrations
{
    public partial class InitialWidgetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Widgets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "ID", "Cost", "Description" },
                values: new object[] { 1, 12f, "Widget 1" });

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "ID", "Cost", "Description" },
                values: new object[] { 2, 15f, "Widget 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Widgets");
        }
    }
}
