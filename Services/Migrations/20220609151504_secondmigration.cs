using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_IndexedFolders",
                table: "IndexedFolders",
                column: "FolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IndexedFolders",
                table: "IndexedFolders");
        }
    }
}
