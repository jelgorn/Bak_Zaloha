using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_NET_Bakalarka.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Predmety",
                columns: table => new
                {
                    PredmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nazov = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Popis = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmety", x => x.PredmetId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rola",
                columns: table => new
                {
                    RolaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nazov = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rola", x => x.RolaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pouzivatelia",
                columns: table => new
                {
                    PouzivatelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Meno = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Priezvisko = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DatumNarodenia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HesloHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RolaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pouzivatelia", x => x.PouzivatelId);
                    table.ForeignKey(
                        name: "FK_Pouzivatelia_Rola_RolaId",
                        column: x => x.RolaId,
                        principalTable: "Rola",
                        principalColumn: "RolaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PriradeniaPredmetovUcitelom",
                columns: table => new
                {
                    PriradenieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UcitelId = table.Column<int>(type: "int", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriradeniaPredmetovUcitelom", x => x.PriradenieId);
                    table.ForeignKey(
                        name: "FK_PriradeniaPredmetovUcitelom_Pouzivatelia_UcitelId",
                        column: x => x.UcitelId,
                        principalTable: "Pouzivatelia",
                        principalColumn: "PouzivatelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriradeniaPredmetovUcitelom_Predmety_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmety",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PriradeniaPredmetovZiakom",
                columns: table => new
                {
                    PriradenieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ZiakId = table.Column<int>(type: "int", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriradeniaPredmetovZiakom", x => x.PriradenieId);
                    table.ForeignKey(
                        name: "FK_PriradeniaPredmetovZiakom_Pouzivatelia_ZiakId",
                        column: x => x.ZiakId,
                        principalTable: "Pouzivatelia",
                        principalColumn: "PouzivatelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriradeniaPredmetovZiakom_Predmety_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmety",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Rola",
                columns: new[] { "RolaId", "Nazov" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Učiteľ" },
                    { 3, "Žiak" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pouzivatelia_RolaId",
                table: "Pouzivatelia",
                column: "RolaId");

            migrationBuilder.CreateIndex(
                name: "IX_PriradeniaPredmetovUcitelom_PredmetId",
                table: "PriradeniaPredmetovUcitelom",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_PriradeniaPredmetovUcitelom_UcitelId",
                table: "PriradeniaPredmetovUcitelom",
                column: "UcitelId");

            migrationBuilder.CreateIndex(
                name: "IX_PriradeniaPredmetovZiakom_PredmetId",
                table: "PriradeniaPredmetovZiakom",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_PriradeniaPredmetovZiakom_ZiakId",
                table: "PriradeniaPredmetovZiakom",
                column: "ZiakId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriradeniaPredmetovUcitelom");

            migrationBuilder.DropTable(
                name: "PriradeniaPredmetovZiakom");

            migrationBuilder.DropTable(
                name: "Pouzivatelia");

            migrationBuilder.DropTable(
                name: "Predmety");

            migrationBuilder.DropTable(
                name: "Rola");
        }
    }
}
