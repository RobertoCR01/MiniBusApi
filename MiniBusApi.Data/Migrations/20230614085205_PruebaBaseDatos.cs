using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniBusManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class PruebaBaseDatos : Migration
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
                    CompanyId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInsert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModifies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInsert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModifies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolDBEntityUserDBEntity",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolDBEntityUserDBEntity", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RolDBEntityUserDBEntity_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolDBEntityUserDBEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "ContactName", "ContactNumber", "Email", "InsertionDate", "ModificationDate", "Name", "Phone", "UserInsert", "UserModifies" },
                values: new object[,]
                {
                    { 1, "359 Avon", "San Jose", "Roberto Diaz", "2655666", "Roberto@gmail.com", new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9274), new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9334), "Prueba", "25655656", "Roberto", "RobertoM" },
                    { 2, "359 chch", "San Jose", "Roberto Perez", "250000", "Roberto@hotmail.com", new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9336), new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9338), "Prueba", "25655656", "Roberto", "RobertoM" }
                });

            migrationBuilder.InsertData(
                table: "Minibuses",
                columns: new[] { "Id", "Brand", "Capacity", "CompanyId", "InsertionDate", "ModificationDate", "Plate", "Tipo", "UserInsert", "UserModifies", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", 20, 2, new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9637), new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9641), "Pak715", "Van", "Roberto", "Roberto", 2020 },
                    { 2, "Mazada", 6, 1, new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9643), new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9645), "CL1715", "Car", null, null, 0 },
                    { 3, "Isuzu", 7, 1, new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9646), new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9647), "BUS715", "Bus", null, null, 0 },
                    { 4, "Ford", 8, 1, new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9650), new DateTime(2023, 6, 14, 20, 52, 5, 668, DateTimeKind.Local).AddTicks(9651), "625630", "Tri", "Roberto", "RobertoM", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Minibuses_CompanyId",
                table: "Minibuses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RolDBEntityUserDBEntity_UsersId",
                table: "RolDBEntityUserDBEntity",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CompanyId",
                table: "Roles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Minibuses");

            migrationBuilder.DropTable(
                name: "RolDBEntityUserDBEntity");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
