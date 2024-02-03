using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllVersusOne.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToGuess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guesses_GameRounds_GameRoundId",
                table: "Guesses");

            migrationBuilder.AlterColumn<int>(
                name: "GameRoundId",
                table: "Guesses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Guesses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Guesses_UserId",
                table: "Guesses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guesses_GameRounds_GameRoundId",
                table: "Guesses",
                column: "GameRoundId",
                principalTable: "GameRounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guesses_Users_UserId",
                table: "Guesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guesses_GameRounds_GameRoundId",
                table: "Guesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Guesses_Users_UserId",
                table: "Guesses");

            migrationBuilder.DropIndex(
                name: "IX_Guesses_UserId",
                table: "Guesses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Guesses");

            migrationBuilder.AlterColumn<int>(
                name: "GameRoundId",
                table: "Guesses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Guesses_GameRounds_GameRoundId",
                table: "Guesses",
                column: "GameRoundId",
                principalTable: "GameRounds",
                principalColumn: "Id");
        }
    }
}
