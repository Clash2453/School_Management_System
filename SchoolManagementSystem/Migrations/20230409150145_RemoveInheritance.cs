using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEvents_Students_StudentUserId",
                table: "StudentEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentUserId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Users_UserId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEvents_Teacher_TeacherUserId",
                table: "TeacherEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teacher_TeacherUserId",
                table: "TeacherSubjects");

            migrationBuilder.RenameColumn(
                name: "TeacherUserId",
                table: "TeacherSubjects",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubjects_TeacherUserId",
                table: "TeacherSubjects",
                newName: "IX_TeacherSubjects_TeacherId");

            migrationBuilder.RenameColumn(
                name: "TeacherUserId",
                table: "TeacherEvents",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherEvents_TeacherUserId",
                table: "TeacherEvents",
                newName: "IX_TeacherEvents_TeacherId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Teacher",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "StudentSubjects",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_StudentUserId",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_StudentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "StudentEvents",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEvents_StudentUserId",
                table: "StudentEvents",
                newName: "IX_StudentEvents_StudentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Admins",
                newName: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_AdminId",
                table: "Admins",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEvents_Students_StudentId",
                table: "StudentEvents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");

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
                principalColumn: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teacher_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_AdminId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEvents_Students_StudentId",
                table: "StudentEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_StudentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Users_TeacherId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEvents_Teacher_TeacherId",
                table: "TeacherEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teacher_TeacherId",
                table: "TeacherSubjects");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "TeacherSubjects",
                newName: "TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubjects_TeacherId",
                table: "TeacherSubjects",
                newName: "IX_TeacherSubjects_TeacherUserId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "TeacherEvents",
                newName: "TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherEvents_TeacherId",
                table: "TeacherEvents",
                newName: "IX_TeacherEvents_TeacherUserId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teacher",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentSubjects",
                newName: "StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_StudentUserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentEvents",
                newName: "StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEvents_StudentId",
                table: "StudentEvents",
                newName: "IX_StudentEvents_StudentUserId");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Admins",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEvents_Students_StudentUserId",
                table: "StudentEvents",
                column: "StudentUserId",
                principalTable: "Students",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentUserId",
                table: "StudentSubjects",
                column: "StudentUserId",
                principalTable: "Students",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Users_UserId",
                table: "Teacher",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEvents_Teacher_TeacherUserId",
                table: "TeacherEvents",
                column: "TeacherUserId",
                principalTable: "Teacher",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teacher_TeacherUserId",
                table: "TeacherSubjects",
                column: "TeacherUserId",
                principalTable: "Teacher",
                principalColumn: "UserId");
        }
    }
}
