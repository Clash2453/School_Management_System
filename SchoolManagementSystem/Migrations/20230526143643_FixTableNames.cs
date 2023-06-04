using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Teacher_TeacherId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Teacher_TeacherId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Teacher_GraderTeacherId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Users_TeacherId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEvents_Teacher_TeacherId",
                table: "TeacherEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teacher_TeacherId",
                table: "TeacherSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Teachers_TeacherId",
                table: "Absences",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Teachers_TeacherId",
                table: "Events",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Teachers_GraderTeacherId",
                table: "Grade",
                column: "GraderTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEvents_Teachers_TeacherId",
                table: "TeacherEvents",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_TeacherId",
                table: "Teachers",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Teachers_TeacherId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Teachers_TeacherId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Teachers_GraderTeacherId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEvents_Teachers_TeacherId",
                table: "TeacherEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_TeacherId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherId",
                table: "TeacherSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Teacher_TeacherId",
                table: "Absences",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Teacher_TeacherId",
                table: "Events",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Teacher_GraderTeacherId",
                table: "Grade",
                column: "GraderTeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Users_TeacherId",
                table: "Teacher",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEvents_Teacher_TeacherId",
                table: "TeacherEvents",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teacher_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
