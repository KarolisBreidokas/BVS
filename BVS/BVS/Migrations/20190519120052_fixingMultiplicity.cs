using Microsoft.EntityFrameworkCore.Migrations;

namespace BVS.Migrations
{
    public partial class fixingMultiplicity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_atmMessages_ATM_Parts_CartridgeId",
                table: "atmMessages");

            migrationBuilder.DropIndex(
                name: "IX_atmMessages_CartridgeId",
                table: "atmMessages");

            migrationBuilder.DropIndex(
                name: "IX_atmMessages_PartId",
                table: "atmMessages");

            migrationBuilder.DropColumn(
                name: "CartridgeId",
                table: "atmMessages");

            migrationBuilder.InsertData(
                table: "ATM_Parts",
                columns: new[] { "Id", "Description", "Discriminator", "Name" },
                values: new object[] { -1, "Description of patr1", "ATM_Part", "Part1" });

            migrationBuilder.InsertData(
                table: "ATM_Parts",
                columns: new[] { "Id", "Description", "Discriminator", "Name", "Nominal" },
                values: new object[] { -2, "Description of cartridge1", "Cartridge", "Cartridge1", 50f });

            migrationBuilder.CreateIndex(
                name: "IX_atmMessages_PartId",
                table: "atmMessages",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_atmMessages_PartId1",
                table: "atmMessages",
                column: "PartId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_atmMessages_ATM_Parts_PartId1",
                table: "atmMessages");

            migrationBuilder.DropIndex(
                name: "IX_atmMessages_PartId",
                table: "atmMessages");

            migrationBuilder.DropIndex(
                name: "IX_atmMessages_PartId1",
                table: "atmMessages");

            migrationBuilder.DeleteData(
                table: "ATM_Parts",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "ATM_Parts",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.AddColumn<int>(
                name: "CartridgeId",
                table: "atmMessages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_atmMessages_CartridgeId",
                table: "atmMessages",
                column: "CartridgeId",
                unique: true,
                filter: "[CartridgeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_atmMessages_PartId",
                table: "atmMessages",
                column: "PartId",
                unique: true,
                filter: "[PartId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_atmMessages_ATM_Parts_CartridgeId",
                table: "atmMessages",
                column: "CartridgeId",
                principalTable: "ATM_Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
