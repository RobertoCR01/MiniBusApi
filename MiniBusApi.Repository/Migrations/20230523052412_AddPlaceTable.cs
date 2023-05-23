using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable



namespace MiniBusManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaceTable : Migration
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
                columns: new[] { "Id", "Brand", "Capacity", "IdCompany", "InsertionDate", "ModificationDate", "Tipo", "UserInsert", "UserModifies", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", "3", 1, new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9723), new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9779), "Van", null, null, 0 },
                    { 2, "Mazada", "6", 1, new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9781), new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9783), "Car", null, null, 0 },
                    { 3, "Isuzu", "7", 1, new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9811), new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9812), "Bus", null, null, 0 },
                    { 4, "Ford", "8", 1, new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9814), new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9815), "Tri", null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Canton", "InsertionDate", "ModificationDate", "Name", "Provincia", "UserInsert", "UserModifies" },
                values: new object[,]
                {
                    { 1, "Puriscal", new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9911), new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9913), "Ruta Herradura", "San José", "Roberto Diaz", "Roberto" },
                    { 2, "Ciudad Colón", new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9915), new DateTime(2023, 5, 23, 17, 24, 12, 35, DateTimeKind.Local).AddTicks(9916), "Ruta del Sol", "San José", "Roberto Diaz", "Roberto" }
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
