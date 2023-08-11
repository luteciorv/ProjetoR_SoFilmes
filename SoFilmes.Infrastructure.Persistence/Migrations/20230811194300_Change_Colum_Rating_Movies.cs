using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoFilmes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Change_Colum_Rating_Movies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Movies",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
