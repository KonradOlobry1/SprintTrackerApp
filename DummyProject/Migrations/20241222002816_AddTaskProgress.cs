using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DummyProject.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<int>(type: "INTEGER", nullable: false),
                    StoryPointsCompleted = table.Column<int>(type: "INTEGER", nullable: false),
                    CompletedBy = table.Column<string>(type: "TEXT", nullable: false),
                    TaskItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskProgress_Tasks_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskProgress_TaskItemId",
                table: "TaskProgress",
                column: "TaskItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskProgress");
        }
    }
}
