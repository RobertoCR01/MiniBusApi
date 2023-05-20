using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniBusManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMiniBusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Minibuses",
                columns: new[] { "Id", "Brand", "Capacity", "IdCompany", "InsertionDate", "ModificationDate", "Tipo", "UserInsert", "UserModifies", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", "3", 1, null, null, "Van", null, null, 0 },
                    { 2, "Mazada", "6", 1, null, null, "Car", null, null, 0 },
                    { 3, "Isuzu", "7", 1, null, null, "Bus", null, null, 0 },
                    { 4, "Ford", "8", 1, null, null, "Tri", null, null, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
