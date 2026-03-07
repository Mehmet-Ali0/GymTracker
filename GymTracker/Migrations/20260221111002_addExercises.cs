using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class addExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "exercises",
                columns: new[] { "Id", "Name", "TargetMuscle" },
                values: new object[,]
                {
                    { 1, "Barbell Bench Press", "Chest" },
                    { 2, "Incline Dumbbell Press", "Chest" },
                    { 3, "Chest Fly (Cable/Machine)", "Chest" },
                    { 4, "Overhead Press", "Shoulders" },
                    { 5, "Lateral Raise", "Shoulders" },
                    { 6, "Barbell Squat", "Legs" },
                    { 7, "Leg Press", "Legs" },
                    { 8, "Leg Extension", "Legs" },
                    { 9, "Leg Curl", "Legs" },
                    { 10, "Deadlift", "Back/Legs" },
                    { 11, "Pull-Ups", "Back" },
                    { 12, "Lat Pulldown", "Back" },
                    { 13, "Bent Over Row", "Back" },
                    { 14, "Barbell Curl", "Biceps" },
                    { 15, "Triceps Pushdown", "Triceps" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "exercises",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
