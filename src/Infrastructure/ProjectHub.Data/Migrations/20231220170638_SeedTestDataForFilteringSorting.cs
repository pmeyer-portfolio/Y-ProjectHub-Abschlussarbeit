using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestDataForFilteringSorting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "AdeleV@ynl4z.onmicrosoft.com", "Adele", "Vance" },
                    { "AlexW@ynl4z.onmicrosoft.com", "Alex", "Wilber" },
                    { "DiegoS@ynl4z.onmicrosoft.com", "Diego", "Siciliani" },
                    { "GradyA@ynl4z.onmicrosoft.com", "Grady", "Archie" },
                    { "HenriettaM@ynl4z.onmicrosoft.com", "Henrietta", "Mueller" },
                    { "IsaiahL@ynl4z.onmicrosoft.com", "Isaiah", "Langer" },
                    { "JohannaL@ynl4z.onmicrosoft.com", "Johanna", "Lorenz" },
                    { "JoniS@ynl4z.onmicrosoft.com", "Joni", "Sherman" },
                    { "LeeG@ynl4z.onmicrosoft.com", "Lee", "Gu" },
                    { "LidiaH@ynl4z.onmicrosoft.com", "Lidia", "Holloway" },
                    { "LynneR@ynl4z.onmicrosoft.com", "Lynne", "Robbins" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Created", "Description", "Status", "Title", "TribeId", "UserUuid" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 1", "New", "Project Title 1", 2, "AlexW@ynl4z.onmicrosoft.com" },
                    { 2, new DateTime(2017, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 2", "New", "Project Title 2", 3, "DiegoS@ynl4z.onmicrosoft.com" },
                    { 3, new DateTime(2003, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 3", "New", "Project Title 3", 4, "GradyA@ynl4z.onmicrosoft.com" },
                    { 4, new DateTime(2018, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 4", "New", "Project Title 4", 5, "HenriettaM@ynl4z.onmicrosoft.com" },
                    { 5, new DateTime(2004, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 5", "New", "Project Title 5", 6, "IsaiahL@ynl4z.onmicrosoft.com" },
                    { 6, new DateTime(2019, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 6", "New", "Project Title 6", 7, "JohannaL@ynl4z.onmicrosoft.com" },
                    { 7, new DateTime(2006, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 7", "New", "Project Title 7", 8, "JoniS@ynl4z.onmicrosoft.com" },
                    { 8, new DateTime(2021, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 8", "New", "Project Title 8", 9, "LeeG@ynl4z.onmicrosoft.com" },
                    { 9, new DateTime(2007, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 9", "New", "Project Title 9", 10, "LidiaH@ynl4z.onmicrosoft.com" },
                    { 10, new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 10", "New", "Project Title 10", 11, "LynneR@ynl4z.onmicrosoft.com" },
                    { 11, new DateTime(2008, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 11", "New", "Project Title 11", 12, "AdeleV@ynl4z.onmicrosoft.com" },
                    { 12, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 12", "New", "Project Title 12", 1, "AlexW@ynl4z.onmicrosoft.com" },
                    { 13, new DateTime(2009, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 13", "New", "Project Title 13", 2, "DiegoS@ynl4z.onmicrosoft.com" },
                    { 14, new DateTime(1996, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 14", "New", "Project Title 14", 3, "GradyA@ynl4z.onmicrosoft.com" },
                    { 15, new DateTime(2011, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 15", "New", "Project Title 15", 4, "HenriettaM@ynl4z.onmicrosoft.com" },
                    { 16, new DateTime(1997, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 16", "New", "Project Title 16", 5, "IsaiahL@ynl4z.onmicrosoft.com" },
                    { 17, new DateTime(2012, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 17", "New", "Project Title 17", 6, "JohannaL@ynl4z.onmicrosoft.com" },
                    { 18, new DateTime(1998, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 18", "New", "Project Title 18", 7, "JoniS@ynl4z.onmicrosoft.com" },
                    { 19, new DateTime(2013, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 19", "New", "Project Title 19", 8, "LeeG@ynl4z.onmicrosoft.com" },
                    { 20, new DateTime(2000, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Description 20", "New", "Project Title 20", 9, "LidiaH@ynl4z.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "ProjectProgrammingLanguages",
                columns: new[] { "ProgrammingLanguageId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 21, 1 },
                    { 2, 2 },
                    { 22, 2 },
                    { 3, 3 },
                    { 23, 3 },
                    { 4, 4 },
                    { 24, 4 },
                    { 5, 5 },
                    { 25, 5 },
                    { 6, 6 },
                    { 26, 6 },
                    { 7, 7 },
                    { 27, 7 },
                    { 8, 8 },
                    { 28, 8 },
                    { 9, 9 },
                    { 29, 9 },
                    { 10, 10 },
                    { 30, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 22, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 24, 4 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 25, 5 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 26, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 27, 7 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 28, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 29, 9 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 30, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 14, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 15, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 16, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 17, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 18, 18 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 19, 19 });

            migrationBuilder.DeleteData(
                table: "ProjectProgrammingLanguages",
                keyColumns: new[] { "ProgrammingLanguageId", "ProjectId" },
                keyValues: new object[] { 20, 20 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "AdeleV@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "AlexW@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "DiegoS@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "GradyA@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "HenriettaM@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "IsaiahL@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "JohannaL@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "JoniS@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "LeeG@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "LidiaH@ynl4z.onmicrosoft.com");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "LynneR@ynl4z.onmicrosoft.com");
        }
    }
}
