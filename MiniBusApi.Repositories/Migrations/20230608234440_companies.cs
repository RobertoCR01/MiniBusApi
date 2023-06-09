using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniBusManagement.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class companies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInsert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Minibuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    UserInsert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModifies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minibuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minibuses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "ContactName", "ContactNumber", "Email", "InsertionDate", "ModificationDate", "Name", "Phone", "UserInsert", "UserModifies" },
                values: new object[] { 1, "359 Avon", "San Jose", "Roberto Diaz", "2655666", "Roberto@gmail.com", new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(100), new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(157), "Prueba", "25655656", "Roberto", "RobertoM" });

            migrationBuilder.InsertData(
                table: "Minibuses",
                columns: new[] { "Id", "Brand", "Capacity", "CompanyId", "InsertionDate", "ModificationDate", "Plate", "Tipo", "UserInsert", "UserModifies", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", 3, null, new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(275), new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(277), "PAK715", "Van", null, null, 0 },
                    { 2, "Mazada", 6, null, new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(279), new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(281), "CL1715", "Car", null, null, 0 },
                    { 3, "Isuzu", 7, null, new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(282), new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(284), "BUS715", "Bus", null, null, 0 },
                    { 4, "Ford", 8, null, new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(286), new DateTime(2023, 6, 9, 11, 44, 40, 73, DateTimeKind.Local).AddTicks(287), "625630", "Tri", null, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Minibuses_CompanyId",
                table: "Minibuses",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Minibuses");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
