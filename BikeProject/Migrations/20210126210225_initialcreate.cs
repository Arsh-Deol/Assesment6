using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeProject.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banch",
                columns: table => new
                {
                    BranchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OpeningTime = table.Column<DateTime>(nullable: false),
                    CloseingTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banch", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "Purchaser",
                columns: table => new
                {
                    PurchaserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DOB = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchaser", x => x.PurchaserID);
                });

            migrationBuilder.CreateTable(
                name: "SaleMan",
                columns: table => new
                {
                    SaleManId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleManName = table.Column<string>(nullable: true),
                    BikeAmount = table.Column<double>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleMan", x => x.SaleManId);
                });

            migrationBuilder.CreateTable(
                name: "BikeSale",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaserID = table.Column<int>(nullable: false),
                    BanchID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeSale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BikeSale_Banch_BanchID",
                        column: x => x.BanchID,
                        principalTable: "Banch",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BikeSale_Purchaser_PurchaserID",
                        column: x => x.PurchaserID,
                        principalTable: "Purchaser",
                        principalColumn: "PurchaserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BikeSale_BanchID",
                table: "BikeSale",
                column: "BanchID");

            migrationBuilder.CreateIndex(
                name: "IX_BikeSale_PurchaserID",
                table: "BikeSale",
                column: "PurchaserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeSale");

            migrationBuilder.DropTable(
                name: "SaleMan");

            migrationBuilder.DropTable(
                name: "Banch");

            migrationBuilder.DropTable(
                name: "Purchaser");
        }
    }
}
