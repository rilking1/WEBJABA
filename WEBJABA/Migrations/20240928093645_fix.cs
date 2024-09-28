using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBJABA.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Photos",
                newName: "Photos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photos",
                table: "Photos",
                newName: "PhotoId");
        }
    }
}
