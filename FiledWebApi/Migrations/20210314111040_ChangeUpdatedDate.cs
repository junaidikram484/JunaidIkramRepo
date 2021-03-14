using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiledWebApi.Migrations
{
    public partial class ChangeUpdatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "PaymentStatusID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 14, 16, 10, 39, 655, DateTimeKind.Local).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "PaymentStatusID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 14, 16, 10, 39, 657, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "PaymentStatusID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 14, 16, 10, 39, 657, DateTimeKind.Local).AddTicks(1954));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "PaymentStatusID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 14, 14, 57, 8, 60, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "PaymentStatusID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 14, 14, 57, 8, 62, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "PaymentStatusID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 3, 14, 14, 57, 8, 62, DateTimeKind.Local).AddTicks(3815));
        }
    }
}
