using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BVS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATM_Parts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Nominal = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATM_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATMs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AditionalInfo = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Online = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: true),
                    Worker_PhoneNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATM_Transports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewAddress = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    AtmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATM_Transports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATM_Transports_ATMs_AtmId",
                        column: x => x.AtmId,
                        principalTable: "ATMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atmMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CartridgeId = table.Column<int>(nullable: true),
                    PartId = table.Column<int>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atmMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_atmMessages_ATMs_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "ATMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atmMessages_ATM_Parts_CartridgeId",
                        column: x => x.CartridgeId,
                        principalTable: "ATM_Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_atmMessages_ATM_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "ATM_Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartInStorage",
                columns: table => new
                {
                    RackId = table.Column<int>(nullable: false),
                    PartId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartInStorage", x => new { x.PartId, x.RackId });
                    table.ForeignKey(
                        name: "FK_PartInStorage_ATM_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "ATM_Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartInStorage_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ArivalDate = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ATMId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => new { x.UserId, x.ATMId });
                    table.ForeignKey(
                        name: "FK_Subscription_ATMs_ATMId",
                        column: x => x.ATMId,
                        principalTable: "ATMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscription_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    WorkerId = table.Column<int>(nullable: true),
                    MessageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_atmMessages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "atmMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderedPart",
                columns: table => new
                {
                    PartId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedPart", x => new { x.PartId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderedPart_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedPart_ATM_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "ATM_Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password", "Surname", "Username" },
                values: new object[] { -1, "Administrator", "karolis.breidokas@ktu.edu", "Karolis", "$2a$10$wXKjdScgnoSGL6jFFDxSD.pngMcqRZZaPyRpUYFX7kdV/964qMMGe", "Breidokas", "Root" });

            migrationBuilder.CreateIndex(
                name: "IX_ATM_Transports_AtmId",
                table: "ATM_Transports",
                column: "AtmId");

            migrationBuilder.CreateIndex(
                name: "IX_atmMessages_AuthorId",
                table: "atmMessages",
                column: "AuthorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_MessageId",
                table: "Jobs",
                column: "MessageId",
                unique: true,
                filter: "[MessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkerId",
                table: "Jobs",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPart_OrderId",
                table: "OrderedPart",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AuthorId",
                table: "Orders",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PartInStorage_RackId",
                table: "PartInStorage",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_JobId",
                table: "Reports",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_WorkerId",
                table: "Reports",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_ATMId",
                table: "Subscription",
                column: "ATMId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_UserId",
                table: "UserReports",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATM_Transports");

            migrationBuilder.DropTable(
                name: "OrderedPart");

            migrationBuilder.DropTable(
                name: "PartInStorage");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "UserReports");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Racks");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "atmMessages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ATMs");

            migrationBuilder.DropTable(
                name: "ATM_Parts");
        }
    }
}
