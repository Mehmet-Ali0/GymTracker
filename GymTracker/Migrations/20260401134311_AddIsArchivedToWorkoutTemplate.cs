using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddIsArchivedToWorkoutTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "WorkoutTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "WorkoutTemplates");
        }
    }
}
