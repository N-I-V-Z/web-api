using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDonHangSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_HangHoa_MaHH",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DONHANGCT_DONHANG",
                table: "ChiTietDonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHangCT_DonHang",
                table: "ChiTietDonHang",
                column: "MaDH",
                principalTable: "DonHang",
                principalColumn: "MaDH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHangCT_HangHoa",
                table: "ChiTietDonHang",
                column: "MaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHangCT_DonHang",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHangCT_HangHoa",
                table: "ChiTietDonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_HangHoa_MaHH",
                table: "ChiTietDonHang",
                column: "MaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DONHANGCT_DONHANG",
                table: "ChiTietDonHang",
                column: "MaDH",
                principalTable: "DonHang",
                principalColumn: "MaDH",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
