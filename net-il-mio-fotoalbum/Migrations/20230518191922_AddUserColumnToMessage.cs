using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_il_mio_fotoalbum.Migrations
{
    /// <inheritdoc />
    public partial class AddUserColumnToMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_messages_UserID",
                table: "messages",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_UserID",
                table: "messages",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_UserID",
                table: "messages");

            migrationBuilder.DropIndex(
                name: "IX_messages_UserID",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "messages");
        }
    }
}
