using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniBusManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Migracion01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Minibuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInsert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModifies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minibuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInsert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModifies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Minibuses",
                columns: new[] { "Id", "Brand", "Capacity", "IdCompany", "InsertionDate", "ModificationDate", "Plate", "Tipo", "UserInsert", "UserModifies", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", "3", 1, new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2742), new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2802), "PAK715", "Van", null, null, 0 },
                    { 2, "Mazada", "6", 1, new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2804), new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2806), "CL1715", "Car", null, null, 0 },
                    { 3, "Isuzu", "7", 1, new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2808), new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2809), "BUS715", "Bus", null, null, 0 },
                    { 4, "Ford", "8", 1, new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2811), new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2812), "625630", "Tri", null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Canton", "InsertionDate", "ModificationDate", "Name", "Provincia", "UserInsert", "UserModifies" },
                values: new object[,]
                {
                    { 1, "Puriscal", new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2931), new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2933), "Ruta Herradura", "San José", "Roberto Diaz", "Roberto" },
                    { 2, "Ciudad Colón", new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2935), new DateTime(2023, 6, 2, 15, 40, 29, 734, DateTimeKind.Local).AddTicks(2936), "Ruta del Sol", "San José", "Roberto Diaz", "Roberto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Minibuses");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
