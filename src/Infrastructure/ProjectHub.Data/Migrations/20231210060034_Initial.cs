using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tribes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    TribeId = table.Column<int>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    UserUuid = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Tribes_TribeId",
                        column: x => x.TribeId,
                        principalTable: "Tribes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_User_UserUuid",
                        column: x => x.UserUuid,
                        principalTable: "User",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "ProjectProgrammingLanguages",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProgrammingLanguageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProgrammingLanguages", x => new { x.ProjectId, x.ProgrammingLanguageId });
                    table.ForeignKey(
                        name: "FK_ProjectProgrammingLanguages_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProgrammingLanguages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Assembly" },
                    { 2, "Befunge" },
                    { 3, "Brainfuck" },
                    { 4, "C#" },
                    { 5, "Chef" },
                    { 6, "Chicken" },
                    { 7, "Clojure" },
                    { 8, "COBOL" },
                    { 9, "Dart" },
                    { 10, "Elm" },
                    { 11, "Elixir" },
                    { 12, "Erlang" },
                    { 13, "F#" },
                    { 14, "Fortran" },
                    { 15, "Go" },
                    { 16, "Groovy" },
                    { 17, "Haskell" },
                    { 18, "Java" },
                    { 19, "JavaScript" },
                    { 20, "Kotlin" },
                    { 21, "Lisp" },
                    { 22, "LOLCODE" },
                    { 23, "Lua" },
                    { 24, "MATLAB" },
                    { 25, "Objective-C" },
                    { 26, "Pascal" },
                    { 27, "Perl" },
                    { 28, "PHP" },
                    { 29, "Piet" },
                    { 30, "Prolog" },
                    { 31, "Python" },
                    { 32, "R" },
                    { 33, "Ruby" },
                    { 34, "Rust" },
                    { 35, "Scala" },
                    { 36, "Shakespeare" },
                    { 37, "Swift" },
                    { 38, "TrumpScript" },
                    { 39, "TypeScript" },
                    { 40, "Whitespace" },
                    { 41, "Webassembly" },
                    { 42, "keine Vorgabe" }
                });

            migrationBuilder.InsertData(
                table: "Tribes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tribe Alpha" },
                    { 2, "Tribe Chi" },
                    { 3, "Tribe Delta" },
                    { 4, "Tribe Gamma" },
                    { 5, "Tribe Iota" },
                    { 6, "Tribe Lambda" },
                    { 7, "Tribe My" },
                    { 8, "Tribe Omega" },
                    { 9, "Tribe Psi" },
                    { 10, "Tribe Sigma" },
                    { 11, "Tribe Tau" },
                    { 12, "Tribe Xi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProgrammingLanguages_ProgrammingLanguageId",
                table: "ProjectProgrammingLanguages",
                column: "ProgrammingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TribeId",
                table: "Projects",
                column: "TribeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserUuid",
                table: "Projects",
                column: "UserUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Tribes");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
