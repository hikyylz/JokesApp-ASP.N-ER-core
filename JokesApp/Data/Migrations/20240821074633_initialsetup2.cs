using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JokesApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost", x => x.BlogId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPost");
        }
    }
}
