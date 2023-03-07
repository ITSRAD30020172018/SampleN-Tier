using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModel.Migrations
{
    public partial class loadedwidgets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "ID", "Cost", "Description" },
                values: new object[] { 3, 12f, "Csv Widget 2" });

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "ID", "Cost", "Description" },
                values: new object[] { 4, 1.3f, "Csv Widget 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Widgets",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Widgets",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
