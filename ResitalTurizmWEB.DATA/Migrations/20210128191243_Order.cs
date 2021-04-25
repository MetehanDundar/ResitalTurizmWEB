using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResitalTurizmWEB.DATA.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turlar_Dosyalar_DosyaID",
                table: "Turlar");

            migrationBuilder.DropTable(
                name: "Konaklamalar");

            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "SeferBolgeler");

            migrationBuilder.DropTable(
                name: "Transferler");

            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropTable(
                name: "UcakFirmalar");

            migrationBuilder.DropTable(
                name: "Dosyalar");

            migrationBuilder.DropTable(
                name: "TransferFirmalar");

            migrationBuilder.DropTable(
                name: "Ofisler");

            migrationBuilder.DropIndex(
                name: "IX_Turlar_DosyaID",
                table: "Turlar");

            migrationBuilder.DropColumn(
                name: "DosyaID",
                table: "Turlar");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_BookingId",
                table: "OrderItem",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DosyaID",
                table: "Turlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dosyalar",
                columns: table => new
                {
                    DosyaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaAlisFiyat = table.Column<float>(type: "real", nullable: false),
                    DosyaSatisFiyat = table.Column<float>(type: "real", nullable: false),
                    DosyaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyalar", x => x.DosyaID);
                });

            migrationBuilder.CreateTable(
                name: "Ofisler",
                columns: table => new
                {
                    OfisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfisAdres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofisler", x => x.OfisID);
                });

            migrationBuilder.CreateTable(
                name: "TransferFirmalar",
                columns: table => new
                {
                    TransferFirmaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolgeBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferFirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferFirmaAdres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferFirmalar", x => x.TransferFirmaID);
                });

            migrationBuilder.CreateTable(
                name: "UcakFirmalar",
                columns: table => new
                {
                    UcakFirmaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UcakFirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UcakFirmaAdres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UcakFirmalar", x => x.UcakFirmaID);
                });

            migrationBuilder.CreateTable(
                name: "Konaklamalar",
                columns: table => new
                {
                    KonaklamaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaID = table.Column<int>(type: "int", nullable: true),
                    GemiID = table.Column<int>(type: "int", nullable: true),
                    KonaklamaFiyat = table.Column<double>(type: "float", nullable: false),
                    KonaklamaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konaklamalar", x => x.KonaklamaID);
                    table.ForeignKey(
                        name: "FK_Konaklamalar_Dosyalar_DosyaID",
                        column: x => x.DosyaID,
                        principalTable: "Dosyalar",
                        principalColumn: "DosyaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Konaklamalar_Gemiler_GemiID",
                        column: x => x.GemiID,
                        principalTable: "Gemiler",
                        principalColumn: "GemiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Konaklamalar_Oteller_OtelID",
                        column: x => x.OtelID,
                        principalTable: "Oteller",
                        principalColumn: "OtelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    CalisanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalisanAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalisanCariKod = table.Column<int>(type: "int", nullable: true),
                    CalisanGorev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalisanSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfisID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.CalisanID);
                    table.ForeignKey(
                        name: "FK_Calisanlar_Ofisler_OfisID",
                        column: x => x.OfisID,
                        principalTable: "Ofisler",
                        principalColumn: "OfisID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transferler",
                columns: table => new
                {
                    TransferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaID = table.Column<int>(type: "int", nullable: true),
                    TransferFirmaID = table.Column<int>(type: "int", nullable: true),
                    TransferFiyat = table.Column<int>(type: "int", nullable: false),
                    TransferGüzergah = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferler", x => x.TransferID);
                    table.ForeignKey(
                        name: "FK_Transferler_Dosyalar_DosyaID",
                        column: x => x.DosyaID,
                        principalTable: "Dosyalar",
                        principalColumn: "DosyaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferler_TransferFirmalar_TransferFirmaID",
                        column: x => x.TransferFirmaID,
                        principalTable: "TransferFirmalar",
                        principalColumn: "TransferFirmaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeferBolgeler",
                columns: table => new
                {
                    UcakSeferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UCakSeferBolgesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UcakFirmaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeferBolgeler", x => x.UcakSeferID);
                    table.ForeignKey(
                        name: "FK_SeferBolgeler_UcakFirmalar_UcakFirmaID",
                        column: x => x.UcakFirmaID,
                        principalTable: "UcakFirmalar",
                        principalColumn: "UcakFirmaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Satislar",
                columns: table => new
                {
                    SatisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaID = table.Column<int>(type: "int", nullable: true),
                    KonaklamaTarihBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KonaklamaTarihBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PnrNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaticiCalisanCalisanID = table.Column<int>(type: "int", nullable: true),
                    SatisCariKod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satislar", x => x.SatisID);
                    table.ForeignKey(
                        name: "FK_Satislar_Calisanlar_SaticiCalisanCalisanID",
                        column: x => x.SaticiCalisanCalisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Satislar_Dosyalar_DosyaID",
                        column: x => x.DosyaID,
                        principalTable: "Dosyalar",
                        principalColumn: "DosyaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turlar_DosyaID",
                table: "Turlar",
                column: "DosyaID");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_OfisID",
                table: "Calisanlar",
                column: "OfisID");

            migrationBuilder.CreateIndex(
                name: "IX_Konaklamalar_DosyaID",
                table: "Konaklamalar",
                column: "DosyaID");

            migrationBuilder.CreateIndex(
                name: "IX_Konaklamalar_GemiID",
                table: "Konaklamalar",
                column: "GemiID");

            migrationBuilder.CreateIndex(
                name: "IX_Konaklamalar_OtelID",
                table: "Konaklamalar",
                column: "OtelID");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_DosyaID",
                table: "Satislar",
                column: "DosyaID");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_SaticiCalisanCalisanID",
                table: "Satislar",
                column: "SaticiCalisanCalisanID");

            migrationBuilder.CreateIndex(
                name: "IX_SeferBolgeler_UcakFirmaID",
                table: "SeferBolgeler",
                column: "UcakFirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Transferler_DosyaID",
                table: "Transferler",
                column: "DosyaID");

            migrationBuilder.CreateIndex(
                name: "IX_Transferler_TransferFirmaID",
                table: "Transferler",
                column: "TransferFirmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Turlar_Dosyalar_DosyaID",
                table: "Turlar",
                column: "DosyaID",
                principalTable: "Dosyalar",
                principalColumn: "DosyaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
