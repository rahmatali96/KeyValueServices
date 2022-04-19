using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyValueServices.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Keys",
                columns: new[] { "key", "value" },
                values: new object[] { "temp_dev0", "87" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Keys",
                keyColumn: "key",
                keyValue: "temp_dev0");
        }
    }
}
