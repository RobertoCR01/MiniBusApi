using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniBusManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3417), new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3469), new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3471) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3472), new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3473) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3475), new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3476) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3577), new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3579) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3581), new DateTime(2023, 5, 28, 19, 32, 20, 865, DateTimeKind.Local).AddTicks(3582) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9458), new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9512), new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9513) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9515), new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9516) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9518), new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9519) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9620), new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9622) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9624), new DateTime(2023, 5, 28, 19, 19, 36, 646, DateTimeKind.Local).AddTicks(9626) });
        }
    }
}
