using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaseStudy4_School_Revission.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "Enrollments",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "Email", "FullName", "Gender", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.hassan@school.com", "Ali Hassan", "Male", "01011111111" },
                    { 2, new DateTime(2010, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam.ahmed@school.com", "Mariam Ahmed", "Female", "01022222222" },
                    { 3, new DateTime(2009, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.khaled@school.com", "Omar Khaled", "Male", "01033333333" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed.samir@school.com", "Ahmed Samir", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01044444444" },
                    { 2, "nour.adel@school.com", "Nour Adel", new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01055555555" },
                    { 3, "hany.mostafa@school.com", "Hany Mostafa", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01066666666" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreditHours", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 1, 3, 1, "Programming Fundamentals" },
                    { 2, 4, 2, "Database Systems" },
                    { 3, 3, 1, "Web Development" }
                });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "Address", "EmergencyContact", "ParentPhone", "StudentId" },
                values: new object[,]
                {
                    { 1, "Nasr City, Cairo", "01211111111", "01111111111", 1 },
                    { 2, "Heliopolis, Cairo", "01222222222", "01122222222", 2 },
                    { 3, "Maadi, Cairo", "01233333333", "01133333333", 3 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 1 },
                    { 2, 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.50m, 2 },
                    { 3, 3, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "Enrollments",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
