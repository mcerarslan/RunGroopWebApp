using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroopWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppUserIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Races_AppUserId' AND object_id = OBJECT_ID('Races'))
                DROP INDEX [IX_Races_AppUserId] ON [dbo].[Races];
            ");

            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Clubs_AppUserId' AND object_id = OBJECT_ID('Clubs'))
                DROP INDEX [IX_Clubs_AppUserId] ON [dbo].[Clubs];
            ");

            // Sütunu nullable yap ve türünü değiştir
            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Races",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            // İndeksleri yeniden oluştur
            migrationBuilder.CreateIndex(
                name: "IX_Races_AppUserId",
                table: "Races",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_AppUserId",
                table: "Clubs",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // İndeksleri kaldır
            migrationBuilder.DropIndex(
                name: "IX_Races_AppUserId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_AppUserId",
                table: "Clubs");

            // Sütunları eski haline döndür
            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Races",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Clubs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            // İndeksleri yeniden oluştur
            migrationBuilder.CreateIndex(
                name: "IX_Races_AppUserId",
                table: "Races",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_AppUserId",
                table: "Clubs",
                column: "AppUserId");
        }
    }
}
