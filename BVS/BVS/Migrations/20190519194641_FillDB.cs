using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BVS.Migrations
{
    public partial class FillDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ATMs",
                columns: new[] { "Id", "Address", "AditionalInfo", "Online", "State" },
                values: new object[,]
                {
                    { -1, "Liepų g. 21", "Šalia Rimi", true, 3 },
                    { -2, "Laisvės al. 5", "", false, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ArivalDate", "Date" },
                values: new object[] { new DateTime(2019, 5, 27, 22, 46, 40, 618, DateTimeKind.Local).AddTicks(9181), new DateTime(2019, 5, 19, 22, 46, 40, 616, DateTimeKind.Local).AddTicks(7825) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Surname", "PhoneNo" },
                values: new object[] { "Stončius", "861514445" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password", "Surname", "Username" },
                values: new object[] { -4, "User", "ltkarolissto@gmail.com", "Artūras", "$2a$10$wXKjdScgnoSGL6jFFDxSD.pngMcqRZZaPyRpUYFX7kdV/964qMMGe", "Paulius", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password", "Surname", "Username", "Worker_PhoneNo" },
                values: new object[] { -3, "Worker", "Tadas.k31@gmail.com", "Tadas", "$2a$10$wXKjdScgnoSGL6jFFDxSD.pngMcqRZZaPyRpUYFX7kdV/964qMMGe", "Kalvaitis", "Worker", "862546645" });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "UserId", "ATMId" },
                values: new object[] { -4, -1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ATMs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumns: new[] { "UserId", "ATMId" },
                keyValues: new object[] { -4, -1 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "ATMs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ArivalDate", "Date" },
                values: new object[] { new DateTime(2019, 5, 27, 16, 46, 11, 409, DateTimeKind.Local).AddTicks(830), new DateTime(2019, 5, 19, 16, 46, 11, 407, DateTimeKind.Local).AddTicks(2639) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Surname", "PhoneNo" },
                values: new object[] { "Stoncius", null });
        }
    }
}
