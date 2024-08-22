using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JokesApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForcastModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tempValue = table.Column<double>(type: "float", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForcastModels", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForcastModels");
        }
    }
}
