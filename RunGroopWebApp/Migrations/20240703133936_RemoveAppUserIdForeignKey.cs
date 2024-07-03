using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroopWebApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAppUserIdForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
            name: "FK_Races_AppUsers_AppUserId",
            table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_AppUsers_AppUserId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Races_AppUserId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_AppUserId",
                table: "Clubs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
           name: "IX_Races_AppUserId",
           table: "Races",
           column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_AppUsers_AppUserId",
                table: "Races",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_AppUserId",
                table: "Clubs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_AppUsers_AppUserId",
                table: "Clubs",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
