using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    courseDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Enrollements",
                columns: table => new
                {
                    enrollementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollements", x => x.enrollementId);
                    table.ForeignKey(
                        name: "FK_Enrollements_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollements_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "courseId", "courseDescription", "courseName" },
                values: new object[,]
                {
                    { 1, "ECE", "ECE" },
                    { 2, "CSE", "CSE" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "studentId", "Address", "DOB", "Email", "StudentName" },
                values: new object[,]
                {
                    { 1, "Baramati", new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "malharp@gmail.com", "Malhar" },
                    { 2, "Satara", new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohitl@gmail.com", "Mohit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollements_courseId",
                table: "Enrollements",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollements_studentId",
                table: "Enrollements",
                column: "studentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollements");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
