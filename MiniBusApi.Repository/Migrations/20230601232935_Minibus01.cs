using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniBusManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Minibus01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3679), new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3739) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3742), new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3745), new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3746) });

            migrationBuilder.UpdateData(
                table: "Minibuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3748), new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3749) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3863), new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3865) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertionDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3868), new DateTime(2023, 6, 2, 11, 29, 35, 805, DateTimeKind.Local).AddTicks(3870) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
