using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrder.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentProductPrice",
                table: "OrderProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "OrderProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "OrderProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "OrderProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductTotal",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a027927-135d-4ac0-b55d-efb28d0118e4"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 8, 27, 4, 452, DateTimeKind.Local).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("42be8c07-c7e6-4582-a980-918e769f809d"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 8, 27, 4, 452, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6fbcfc5-e4dd-4b66-8098-d56f5e1408a6"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 8, 27, 4, 452, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("46798df4-d5b9-4dd8-95a0-f8f8bfb172f8"),
                columns: new[] { "ContactNumber", "DateCreated", "Email" },
                values: new object[] { "081-3110121", new DateTime(2020, 5, 27, 8, 27, 4, 452, DateTimeKind.Local).AddTicks(135), "golden@nomail.com" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("892228bf-8380-419d-9518-a310f74e30c5"),
                columns: new[] { "ContactNumber", "DateCreated", "Email" },
                values: new object[] { "051-9182102", new DateTime(2020, 5, 27, 8, 27, 4, 452, DateTimeKind.Local).AddTicks(139), "summit@nomail.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4194ff3b-0c2d-456b-8314-08f7ee3bc8e0"),
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 5, 27, 8, 27, 4, 452, DateTimeKind.Local).AddTicks(1799), 60m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("760f4974-68d6-4403-aff6-29ef670abd01"),
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 5, 27, 8, 27, 4, 452, DateTimeKind.Local).AddTicks(1775), 40m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d0bcb8d-e459-4885-975a-588741fe1905"),
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 5, 27, 8, 27, 4, 452, DateTimeKind.Local).AddTicks(1769), 20m });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("418eca24-a89f-4310-a8a0-6d12dd96dc6a"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 27, 8, 27, 4, 451, DateTimeKind.Local).AddTicks(9203));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CurrentProductPrice",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductTotal",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a027927-135d-4ac0-b55d-efb28d0118e4"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("42be8c07-c7e6-4582-a980-918e769f809d"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6fbcfc5-e4dd-4b66-8098-d56f5e1408a6"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("46798df4-d5b9-4dd8-95a0-f8f8bfb172f8"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("892228bf-8380-419d-9518-a310f74e30c5"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4194ff3b-0c2d-456b-8314-08f7ee3bc8e0"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("760f4974-68d6-4403-aff6-29ef670abd01"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d0bcb8d-e459-4885-975a-588741fe1905"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("418eca24-a89f-4310-a8a0-6d12dd96dc6a"),
                column: "DateCreated",
                value: new DateTime(2020, 5, 26, 20, 42, 38, 378, DateTimeKind.Local).AddTicks(4150));
        }
    }
}