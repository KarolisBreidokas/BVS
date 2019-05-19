using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BVS.Migrations
{
    public partial class New_Order_and_Parts_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ATM_Parts",
                columns: new[] { "Id", "Description", "Discriminator", "Name" },
                values: new object[] { -3, "Description of patr2", "ATM_Part", "Part2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password", "Surname", "Username", "PhoneNo" },
                values: new object[] { -2, "StorageWorker", "karolis.stoncius@ktu.edu", "Karolis", "$2a$10$wXKjdScgnoSGL6jFFDxSD.pngMcqRZZaPyRpUYFX7kdV/964qMMGe", "Stoncius", "Storage", null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArivalDate", "AuthorId", "Date" },
                values: new object[] { -1, new DateTime(2019, 5, 27, 16, 46, 11, 409, DateTimeKind.Local).AddTicks(830), -2, new DateTime(2019, 5, 19, 16, 46, 11, 407, DateTimeKind.Local).AddTicks(2639) });

            migrationBuilder.InsertData(
                table: "OrderedPart",
                columns: new[] { "PartId", "OrderId", "Price" },
                values: new object[] { -1, -1, 30f });

            migrationBuilder.InsertData(
                table: "OrderedPart",
                columns: new[] { "PartId", "OrderId", "Price" },
                values: new object[] { -2, -1, 40f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ATM_Parts",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "OrderedPart",
                keyColumns: new[] { "PartId", "OrderId" },
                keyValues: new object[] { -2, -1 });

            migrationBuilder.DeleteData(
                table: "OrderedPart",
                keyColumns: new[] { "PartId", "OrderId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2);
        }
    }
}
