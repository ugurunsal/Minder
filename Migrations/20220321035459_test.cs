using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minder.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MatchedUserId = table.Column<int>(type: "int", nullable: false),
                    IsMatch = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDislike = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    School = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AboutMe = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Company = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LivingIn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Longtitude = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsBlocked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsVisible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiscoverySettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DistancePreference = table.Column<int>(type: "int", nullable: false),
                    MinAgePreference = table.Column<int>(type: "int", nullable: false),
                    MaxAgePreference = table.Column<int>(type: "int", nullable: false),
                    GenderPreference = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverySettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscoverySettings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Passion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passion_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "AccountId", "BirthDate", "Company", "FirstName", "Gender", "JobTitle", "LastName", "Latitude", "LivingIn", "Location", "Longtitude", "School" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(1999, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ugur", 0, null, "Unsal", 41.065006179484264, null, null, 28.99362576838913, null },
                    { 2, null, 2, new DateTime(1997, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Onur", 0, null, "Unsal", 40.991271937094083, null, null, 28.83275948060281, null },
                    { 3, null, 3, new DateTime(1990, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Utku", 0, null, "Demir", 41.086011370754782, null, null, 28.276755762445031, null },
                    { 4, null, 4, new DateTime(1980, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ersen", 0, null, "Uncu", 41.213846436184397, null, null, 28.765439420948827, null },
                    { 5, null, 5, new DateTime(2004, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ozgur", 0, null, "Ozturk", 40.806779694918674, null, null, 29.35884100723468, null },
                    { 6, null, 6, new DateTime(2003, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İdil", 1, null, "Nihan", 41.06150009946095, null, null, 28.999743808045224, null },
                    { 7, null, 7, new DateTime(1995, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Setenay", 1, null, "Eyigun", 40.976113655976135, null, null, 28.730090714252068, null },
                    { 8, null, 8, new DateTime(1990, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Goksen", 1, null, "Bakay", 41.078791954503508, null, null, 28.302878176490744, null },
                    { 9, null, 9, new DateTime(1985, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seyma", 1, null, "Deveci", 40.136680128545606, null, null, 29.046779860031538, null },
                    { 10, null, 10, new DateTime(1970, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alara", 1, null, "Sakarya", 40.850822025300388, null, null, 30.115398352304844, null }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "IsBlocked", "IsVisible", "Password", "UserId" },
                values: new object[,]
                {
                    { 1, "ugurunsal@gmail.com", false, true, "123456", 1 },
                    { 2, "onurunsal@gmail.com", false, true, "123456", 2 },
                    { 3, "utkudemir@gmail.com", false, true, "123456", 3 },
                    { 4, "ersenuncu@gmail.com", false, true, "123456", 4 },
                    { 5, "ozgurozturk@gmail.com", false, true, "123456", 5 },
                    { 6, "idilnihan@gmail.com", false, true, "654321", 6 },
                    { 7, "setenay@gmail.com", false, true, "654321", 7 },
                    { 8, "goksenbakay@gmail.com", false, true, "654321", 8 },
                    { 9, "seymadeveci@gmail.com", false, true, "654321", 9 },
                    { 10, "alarasakarya@gmail.com", false, true, "654321", 10 }
                });

            migrationBuilder.InsertData(
                table: "DiscoverySettings",
                columns: new[] { "Id", "DistancePreference", "GenderPreference", "MaxAgePreference", "MinAgePreference", "UserId" },
                values: new object[,]
                {
                    { 1, 100, 1, 28, 18, 1 },
                    { 2, 100, 1, 28, 18, 2 },
                    { 3, 100, 1, 28, 18, 3 },
                    { 4, 100, 1, 28, 18, 4 },
                    { 5, 100, 1, 28, 18, 5 },
                    { 6, 100, 0, 28, 18, 6 },
                    { 7, 100, 0, 28, 18, 7 },
                    { 8, 100, 0, 28, 18, 8 },
                    { 9, 100, 0, 28, 18, 9 },
                    { 10, 100, 0, 28, 18, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscoverySettings_UserId",
                table: "DiscoverySettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passion_UserId",
                table: "Passion",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "DiscoverySettings");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Passion");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
