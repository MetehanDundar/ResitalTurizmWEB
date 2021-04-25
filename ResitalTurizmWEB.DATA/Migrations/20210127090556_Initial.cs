using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResitalTurizmWEB.DATA.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dosyalar",
                columns: table => new
                {
                    DosyaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaAlisFiyat = table.Column<float>(type: "real", nullable: false),
                    DosyaSatisFiyat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyalar", x => x.DosyaID);
                });

            migrationBuilder.CreateTable(
                name: "GemiFirmalar",
                columns: table => new
                {
                    GemiFirmaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GemiFirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GemiFirmaAdres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GemiFirmalar", x => x.GemiFirmaID);
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
                name: "OtelKategorileri",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtelKategorisi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtelKategorileri", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "TransferFirmalar",
                columns: table => new
                {
                    TransferFirmaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferFirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferFirmaAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolgeBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferFirmalar", x => x.TransferFirmaID);
                });

            migrationBuilder.CreateTable(
                name: "TurSirketler",
                columns: table => new
                {
                    TurSirketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurSirketAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurSirketAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolgeBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurSirketler", x => x.TurSirketID);
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
                name: "Gemiler",
                columns: table => new
                {
                    GemiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GemiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    GemiFirmaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemiler", x => x.GemiID);
                    table.ForeignKey(
                        name: "FK_Gemiler_GemiFirmalar_GemiFirmaID",
                        column: x => x.GemiFirmaID,
                        principalTable: "GemiFirmalar",
                        principalColumn: "GemiFirmaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    CalisanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalisanSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalisanAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalisanCariKod = table.Column<int>(type: "int", nullable: true),
                    CalisanGorev = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Oteller",
                columns: table => new
                {
                    OtelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    OtelAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtelKategorisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtelAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oteller", x => x.OtelID);
                    table.ForeignKey(
                        name: "FK_Oteller_OtelKategorileri_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "OtelKategorileri",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferler",
                columns: table => new
                {
                    TransferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferGüzergah = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferFiyat = table.Column<int>(type: "int", nullable: false),
                    TransferFirmaID = table.Column<int>(type: "int", nullable: true),
                    DosyaID = table.Column<int>(type: "int", nullable: true)
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
                name: "Rehberler",
                columns: table => new
                {
                    TurRehberD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurRehberAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurRehberAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurSirketID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rehberler", x => x.TurRehberD);
                    table.ForeignKey(
                        name: "FK_Rehberler_TurSirketler_TurSirketID",
                        column: x => x.TurSirketID,
                        principalTable: "TurSirketler",
                        principalColumn: "TurSirketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurAraclar",
                columns: table => new
                {
                    TurAracID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAracTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurSirketID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurAraclar", x => x.TurAracID);
                    table.ForeignKey(
                        name: "FK_TurAraclar_TurSirketler_TurSirketID",
                        column: x => x.TurSirketID,
                        principalTable: "TurSirketler",
                        principalColumn: "TurSirketID",
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
                    KonaklamaTarihBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KonaklamaTarihBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PnrNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SatisCariKod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaticiCalisanCalisanID = table.Column<int>(type: "int", nullable: true),
                    DosyaID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Konaklamalar",
                columns: table => new
                {
                    KonaklamaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonaklamaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KonaklamaFiyat = table.Column<double>(type: "float", nullable: false),
                    DosyaID = table.Column<int>(type: "int", nullable: true),
                    OtelID = table.Column<int>(type: "int", nullable: true),
                    GemiID = table.Column<int>(type: "int", nullable: true)
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
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtelId = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Oteller_OtelId",
                        column: x => x.OtelId,
                        principalTable: "Oteller",
                        principalColumn: "OtelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turlar",
                columns: table => new
                {
                    TurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurFiyat = table.Column<int>(type: "int", nullable: false),
                    TurBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurSirketID = table.Column<int>(type: "int", nullable: true),
                    TurAracID = table.Column<int>(type: "int", nullable: true),
                    DosyaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turlar", x => x.TurID);
                    table.ForeignKey(
                        name: "FK_Turlar_Dosyalar_DosyaID",
                        column: x => x.DosyaID,
                        principalTable: "Dosyalar",
                        principalColumn: "DosyaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turlar_TurAraclar_TurAracID",
                        column: x => x.TurAracID,
                        principalTable: "TurAraclar",
                        principalColumn: "TurAracID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turlar_TurSirketler_TurSirketID",
                        column: x => x.TurSirketID,
                        principalTable: "TurSirketler",
                        principalColumn: "TurSirketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OtelId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Oteller_OtelId",
                        column: x => x.OtelId,
                        principalTable: "Oteller",
                        principalColumn: "OtelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_OtelId",
                table: "Booking",
                column: "OtelId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomId",
                table: "Booking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_OfisID",
                table: "Calisanlar",
                column: "OfisID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookingId",
                table: "CartItems",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Gemiler_GemiFirmaID",
                table: "Gemiler",
                column: "GemiFirmaID");

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
                name: "IX_Oteller_CategoryID",
                table: "Oteller",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Rehberler_TurSirketID",
                table: "Rehberler",
                column: "TurSirketID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_OtelId",
                table: "Room",
                column: "OtelId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TurAraclar_TurSirketID",
                table: "TurAraclar",
                column: "TurSirketID");

            migrationBuilder.CreateIndex(
                name: "IX_Turlar_DosyaID",
                table: "Turlar",
                column: "DosyaID");

            migrationBuilder.CreateIndex(
                name: "IX_Turlar_TurAracID",
                table: "Turlar",
                column: "TurAracID");

            migrationBuilder.CreateIndex(
                name: "IX_Turlar_TurSirketID",
                table: "Turlar",
                column: "TurSirketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Konaklamalar");

            migrationBuilder.DropTable(
                name: "Rehberler");

            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "SeferBolgeler");

            migrationBuilder.DropTable(
                name: "Transferler");

            migrationBuilder.DropTable(
                name: "Turlar");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Gemiler");

            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropTable(
                name: "UcakFirmalar");

            migrationBuilder.DropTable(
                name: "TransferFirmalar");

            migrationBuilder.DropTable(
                name: "Dosyalar");

            migrationBuilder.DropTable(
                name: "TurAraclar");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "GemiFirmalar");

            migrationBuilder.DropTable(
                name: "Ofisler");

            migrationBuilder.DropTable(
                name: "TurSirketler");

            migrationBuilder.DropTable(
                name: "Oteller");

            migrationBuilder.DropTable(
                name: "OtelKategorileri");
        }
    }
}
