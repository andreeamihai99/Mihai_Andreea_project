using Microsoft.EntityFrameworkCore.Migrations;

namespace Mihai_Andreea_project.Migrations
{
    public partial class RecordLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordLabelID",
                table: "Song",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecordLabel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordLabelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordLabel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_RecordLabelID",
                table: "Song",
                column: "RecordLabelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_RecordLabel_RecordLabelID",
                table: "Song",
                column: "RecordLabelID",
                principalTable: "RecordLabel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_RecordLabel_RecordLabelID",
                table: "Song");

            migrationBuilder.DropTable(
                name: "RecordLabel");

            migrationBuilder.DropIndex(
                name: "IX_Song_RecordLabelID",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "RecordLabelID",
                table: "Song");
        }
    }
}
