using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_Manager_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedTaskData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetTimeinHours = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "TargetTimeinHours", "TaskDescription", "TaskName" },
                values: new object[,]
                {
                    { 1, 3.0, "Studying for new Job", "Study" },
                    { 2, 0.5, "", "Running" },
                    { 3, 1.0, "", "Workout" },
                    { 4, 2.0, "Learning Cooking for Birthday", "Cooking" },
                    { 5, 0.5, "", "Yoga" },
                    { 6, 2.0, "", "project Completion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
