using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalTwitter.Migrations
{
    public partial class migracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Siguiendo",
                columns: table => new
                {
                    IdAccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioSiguiendo = table.Column<int>(type: "int", nullable: false),
                    SeguidorUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siguiendo", x => x.IdAccion);
                    table.ForeignKey(
                        name: "FK_Siguiendo_Usuarios_SeguidorUsuarioId",
                        column: x => x.SeguidorUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    TweetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.TweetId);
                    table.ForeignKey(
                        name: "FK_Tweets_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siguiendo_SeguidorUsuarioId",
                table: "Siguiendo",
                column: "SeguidorUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_UsuarioId",
                table: "Tweets",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siguiendo");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
