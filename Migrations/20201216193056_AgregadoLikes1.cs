using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalTwitter.Migrations
{
    public partial class AgregadoLikes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    IdLike = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTweet = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioLikeo = table.Column<int>(type: "int", nullable: false),
                    LikeadorUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.IdLike);
                    table.ForeignKey(
                        name: "FK_Likes_Usuarios_LikeadorUsuarioId",
                        column: x => x.LikeadorUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikeadorUsuarioId",
                table: "Likes",
                column: "LikeadorUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");
        }
    }
}
