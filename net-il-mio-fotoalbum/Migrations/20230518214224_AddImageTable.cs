using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_il_mio_fotoalbum.Migrations
{
    /// <inheritdoc />
    public partial class AddImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_UserID",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "photos");

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_photos_ImageID",
                table: "photos",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_UserID",
                table: "messages",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_images_ImageID",
                table: "photos",
                column: "ImageID",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_UserID",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_images_ImageID",
                table: "photos");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropIndex(
                name: "IX_photos_ImageID",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "photos");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_UserID",
                table: "messages",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
