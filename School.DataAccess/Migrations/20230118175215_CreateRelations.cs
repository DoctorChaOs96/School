using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StudentId",
                table: "Scores",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_SubjectId",
                table: "Scores",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Students_StudentId",
                table: "Scores",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Subjects_SubjectId",
                table: "Scores",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Students_StudentId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Subjects_SubjectId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Scores_StudentId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_SubjectId",
                table: "Scores");
        }
    }
}
