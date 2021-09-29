using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DoctorWho.Db.Migrations
{
    public partial class CreateAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAuthor",
                columns: table => new
                {
                    tblAutorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuthor", x => x.tblAutorID);
                });

            migrationBuilder.CreateTable(
                name: "tblCompanion",
                columns: table => new
                {
                    tblCompanionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companionName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WhoPlayed = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompanion", x => x.tblCompanionID);
                });

            migrationBuilder.CreateTable(
                name: "tblDoctor",
                columns: table => new
                {
                    tblDoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorNumber = table.Column<int>(type: "int", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDoctor", x => x.tblDoctorID);
                });

            migrationBuilder.CreateTable(
                name: "tblEnemy",
                columns: table => new
                {
                    tblEnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEnemy", x => x.tblEnemyId);
                });

            migrationBuilder.CreateTable(
                name: "tblEpisode",
                columns: table => new
                {
                    tblEpisodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodeType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tblAuthorID = table.Column<int>(type: "int", nullable: false),
                    tblDoctorID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEpisode", x => x.tblEpisodeID);
                    table.ForeignKey(
                        name: "FK_tblEpisode_tblAuthor_tblAuthorID",
                        column: x => x.tblAuthorID,
                        principalTable: "tblAuthor",
                        principalColumn: "tblAutorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEpisode_tblDoctor_tblDoctorID",
                        column: x => x.tblDoctorID,
                        principalTable: "tblDoctor",
                        principalColumn: "tblDoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEpisodeCompanion",
                columns: table => new
                {
                    tblEpisodeCompanionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tblCompanionID = table.Column<int>(type: "int", nullable: false),
                    tblEpisodeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEpisodeCompanion", x => x.tblEpisodeCompanionID);
                    table.ForeignKey(
                        name: "FK_tblEpisodeCompanion_tblCompanion_tblCompanionID",
                        column: x => x.tblCompanionID,
                        principalTable: "tblCompanion",
                        principalColumn: "tblCompanionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEpisodeCompanion_tblEpisode_tblEpisodeID",
                        column: x => x.tblEpisodeID,
                        principalTable: "tblEpisode",
                        principalColumn: "tblEpisodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEpisodeEnemy",
                columns: table => new
                {
                    tblEpisodeEnemyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tblEpisodeID = table.Column<int>(type: "int", nullable: false),
                    tblEnemyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEpisodeEnemy", x => x.tblEpisodeEnemyID);
                    table.ForeignKey(
                        name: "FK_tblEpisodeEnemy_tblEnemy_tblEnemyID",
                        column: x => x.tblEnemyID,
                        principalTable: "tblEnemy",
                        principalColumn: "tblEnemyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEpisodeEnemy_tblEpisode_tblEpisodeID",
                        column: x => x.tblEpisodeID,
                        principalTable: "tblEpisode",
                        principalColumn: "tblEpisodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisode_tblAuthorID",
                table: "tblEpisode",
                column: "tblAuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisode_tblDoctorID",
                table: "tblEpisode",
                column: "tblDoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeCompanion_tblCompanionID",
                table: "tblEpisodeCompanion",
                column: "tblCompanionID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeCompanion_tblEpisodeID",
                table: "tblEpisodeCompanion",
                column: "tblEpisodeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeEnemy_tblEnemyID",
                table: "tblEpisodeEnemy",
                column: "tblEnemyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeEnemy_tblEpisodeID",
                table: "tblEpisodeEnemy",
                column: "tblEpisodeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEpisodeCompanion");

            migrationBuilder.DropTable(
                name: "tblEpisodeEnemy");

            migrationBuilder.DropTable(
                name: "tblCompanion");

            migrationBuilder.DropTable(
                name: "tblEnemy");

            migrationBuilder.DropTable(
                name: "tblEpisode");

            migrationBuilder.DropTable(
                name: "tblAuthor");

            migrationBuilder.DropTable(
                name: "tblDoctor");
        }
    }
}
