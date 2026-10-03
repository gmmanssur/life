using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDecriptionToTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "homeworks",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "homeworks",
                newName: "Description");
        }
    }
}
