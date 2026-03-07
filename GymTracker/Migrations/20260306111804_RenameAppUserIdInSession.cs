using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class RenameAppUserIdInSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_AspNetUsers_AppuserId",
                table: "WorkoutSessions");

            migrationBuilder.RenameColumn(
                name: "AppuserId",
                table: "WorkoutSessions",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSessions_AppuserId",
                table: "WorkoutSessions",
                newName: "IX_WorkoutSessions_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_AspNetUsers_AppUserId",
                table: "WorkoutSessions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_AspNetUsers_AppUserId",
                table: "WorkoutSessions");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "WorkoutSessions",
                newName: "AppuserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSessions_AppUserId",
                table: "WorkoutSessions",
                newName: "IX_WorkoutSessions_AppuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_AspNetUsers_AppuserId",
                table: "WorkoutSessions",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
