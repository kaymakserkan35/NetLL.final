using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NettLL.Design.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Moive",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    moive = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    copyright = table.Column<int>(type: "INTEGER", nullable: false),
                    season = table.Column<int>(type: "INTEGER", nullable: false),
                    epidose = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moive", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sound",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sound = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sound", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    word = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MoiveWord",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    wordId = table.Column<int>(type: "INTEGER", nullable: false),
                    moiveId = table.Column<int>(type: "INTEGER", nullable: false),
                    startTime = table.Column<string>(type: "TEXT", nullable: false),
                    endTime = table.Column<string>(type: "TEXT", nullable: false),
                    line = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoiveWord", x => x.id);
                    table.ForeignKey(
                        name: "FK_MoiveWord_Moive_moiveId",
                        column: x => x.moiveId,
                        principalTable: "Moive",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoiveWord_Word_wordId",
                        column: x => x.wordId,
                        principalTable: "Word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    wordId = table.Column<int>(type: "INTEGER", nullable: false),
                    categoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_WordCategory_Category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordCategory_Word_wordId",
                        column: x => x.wordId,
                        principalTable: "Word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordSound",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    soundId = table.Column<int>(type: "INTEGER", nullable: false),
                    wordId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordSound", x => x.id);
                    table.ForeignKey(
                        name: "FK_WordSound_Sound_soundId",
                        column: x => x.soundId,
                        principalTable: "Sound",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordSound_Word_wordId",
                        column: x => x.wordId,
                        principalTable: "Word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoiveWord_moiveId",
                table: "MoiveWord",
                column: "moiveId");

            migrationBuilder.CreateIndex(
                name: "IX_MoiveWord_wordId",
                table: "MoiveWord",
                column: "wordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordCategory_categoryId",
                table: "WordCategory",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WordCategory_wordId",
                table: "WordCategory",
                column: "wordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordSound_soundId",
                table: "WordSound",
                column: "soundId");

            migrationBuilder.CreateIndex(
                name: "IX_WordSound_wordId",
                table: "WordSound",
                column: "wordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoiveWord");

            migrationBuilder.DropTable(
                name: "WordCategory");

            migrationBuilder.DropTable(
                name: "WordSound");

            migrationBuilder.DropTable(
                name: "Moive");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Sound");

            migrationBuilder.DropTable(
                name: "Word");
        }
    }
}
