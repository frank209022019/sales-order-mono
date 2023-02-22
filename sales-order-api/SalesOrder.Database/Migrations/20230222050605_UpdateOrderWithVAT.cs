using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrder.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderWithVAT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VAT",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a027927-135d-4ac0-b55d-efb28d0118e4"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("42be8c07-c7e6-4582-a980-918e769f809d"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6fbcfc5-e4dd-4b66-8098-d56f5e1408a6"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("46798df4-d5b9-4dd8-95a0-f8f8bfb172f8"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("892228bf-8380-419d-9518-a310f74e30c5"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4194ff3b-0c2d-456b-8314-08f7ee3bc8e0"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("760f4974-68d6-4403-aff6-29ef670abd01"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d0bcb8d-e459-4885-975a-588741fe1905"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("418eca24-a89f-4310-a8a0-6d12dd96dc6a"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 28, 7, 6, 4, 945, DateTimeKind.Local).AddTicks(4157));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VAT",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a027927-135d-4ac0-b55d-efb28d0118e4"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("42be8c07-c7e6-4582-a980-918e769f809d"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6fbcfc5-e4dd-4b66-8098-d56f5e1408a6"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("46798df4-d5b9-4dd8-95a0-f8f8bfb172f8"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("892228bf-8380-419d-9518-a310f74e30c5"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4194ff3b-0c2d-456b-8314-08f7ee3bc8e0"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("760f4974-68d6-4403-aff6-29ef670abd01"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d0bcb8d-e459-4885-975a-588741fe1905"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("418eca24-a89f-4310-a8a0-6d12dd96dc6a"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 19, 28, 16, 76, DateTimeKind.Local).AddTicks(1060));
        }
    }
}