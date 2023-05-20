using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniBusManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMiniBusTableWithCreationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 16, 18, 41, 34, 994, DateTimeKind.Local).AddTicks(5333), new DateTime(2023, 5, 16, 18, 41, 34, 994, DateTimeKind.Local).AddTicks(5395) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 16, 18, 41, 34, 994, DateTimeKind.Local).AddTicks(5397), new DateTime(2023, 5, 16, 18, 41, 34, 994, DateTimeKind.Local).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 16, 18, 41, 34, 994, DateTimeKind.Local).AddTicks(5400), new DateTime(2023, 5, 16, 18, 41, 34, 994, DateTimeKind.Local).AddTicks(5401) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 16, 18, 41, 34, 994, DateTimeKind.Local).AddTicks(5403), new DateTime(2023, 5, 16, 18, 41, 34, 994, DateTimeKind.Local).AddTicks(5404) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { null, null });
        }
    }
}
