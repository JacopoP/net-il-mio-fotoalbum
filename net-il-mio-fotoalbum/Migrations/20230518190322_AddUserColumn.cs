using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_il_mio_fotoalbum.Migrations
{
    /// <inheritdoc />
    public partial class AddUserColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "photos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_photos_UserId",
                table: "photos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_AspNetUsers_UserId",
                table: "photos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_AspNetUsers_UserId",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_UserId",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "photos");
        }
    }
}
