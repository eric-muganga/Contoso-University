using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Contoso_University.Migrations
{
    /// <inheritdoc />
    public partial class ComplexDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");


            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignments", x => new { x.CourseID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK_CourseAssignments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignments_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID");
                });

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "OfficeAssignments",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignments", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_OfficeAssignments_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1045,
                column: "DepartmentID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1050,
                column: "DepartmentID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2021,
                column: "DepartmentID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2042,
                column: "DepartmentID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3141,
                column: "DepartmentID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4022,
                column: "DepartmentID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4041,
                column: "DepartmentID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 5,
                column: "Grade",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 6,
                column: "Grade",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 8,
                columns: new[] { "CourseID", "Grade", "StudentID" },
                values: new object[] { 4022, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 9,
                columns: new[] { "CourseID", "Grade" },
                values: new object[] { 1050, 1 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 10,
                columns: new[] { "CourseID", "Grade" },
                values: new object[] { 2021, 1 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 11,
                columns: new[] { "CourseID", "Grade" },
                values: new object[] { 2042, 1 });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "ID", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, "Kim", new DateTime(1995, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abercrombie" },
                    { 2, "Fadi", new DateTime(2002, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fakhouri" },
                    { 3, "Roger", new DateTime(1998, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harui" },
                    { 4, "Candace", new DateTime(2001, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor" },
                    { 5, "Roger", new DateTime(2004, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zheng" }
                });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "CourseID", "InstructorID" },
                values: new object[,]
                {
                    { 1045, 2 },
                    { 1050, 3 },
                    { 1050, 4 },
                    { 2021, 1 },
                    { 2042, 1 },
                    { 3141, 3 },
                    { 4022, 5 },
                    { 4041, 5 }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Budget", "InstructorID", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 350000m, 1, "English", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 100000m, 2, "Mathematics", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 350000m, 3, "Engineering", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 100000m, 4, "Economics", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OfficeAssignments",
                columns: new[] { "InstructorID", "Location" },
                values: new object[,]
                {
                    { 2, "Smith 17" },
                    { 3, "Gowan 27" },
                    { 4, "Thompson 304" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_InstructorID",
                table: "CourseAssignments",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstructorID",
                table: "Departments",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "OfficeAssignments");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 5,
                column: "Grade",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 6,
                column: "Grade",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 8,
                columns: new[] { "CourseID", "Grade", "StudentID" },
                values: new object[] { 1050, null, 4 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 9,
                columns: new[] { "CourseID", "Grade" },
                values: new object[] { 4022, 4 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 10,
                columns: new[] { "CourseID", "Grade" },
                values: new object[] { 4041, 2 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 11,
                columns: new[] { "CourseID", "Grade" },
                values: new object[] { 1045, null });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentID", "CourseID", "Grade", "StudentID" },
                values: new object[] { 12, 3141, 0, 7 });
        }
    }
}
