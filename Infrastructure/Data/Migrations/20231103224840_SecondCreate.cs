using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "IdDriver",
                table: "teamdriver");

            migrationBuilder.DropForeignKey(
                name: "IdTeam",
                table: "teamdriver");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "teamdriver");

            migrationBuilder.DropIndex(
                name: "IdDriver_idx",
                table: "teamdriver");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teamdriver",
                table: "teamdriver",
                columns: new[] { "IdDriver", "IdTeam" });

            migrationBuilder.CreateIndex(
                name: "IX_teamdriver_IdTeam",
                table: "teamdriver",
                column: "IdTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_teamdriver_driver_IdDriver",
                table: "teamdriver",
                column: "IdDriver",
                principalTable: "driver",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teamdriver_team_IdTeam",
                table: "teamdriver",
                column: "IdTeam",
                principalTable: "team",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teamdriver_driver_IdDriver",
                table: "teamdriver");

            migrationBuilder.DropForeignKey(
                name: "FK_teamdriver_team_IdTeam",
                table: "teamdriver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teamdriver",
                table: "teamdriver");

            migrationBuilder.DropIndex(
                name: "IX_teamdriver_IdTeam",
                table: "teamdriver");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "teamdriver",
                columns: new[] { "IdTeam", "IdDriver" })
                .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IdDriver_idx",
                table: "teamdriver",
                column: "IdDriver");

            migrationBuilder.AddForeignKey(
                name: "IdDriver",
                table: "teamdriver",
                column: "IdDriver",
                principalTable: "driver",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "IdTeam",
                table: "teamdriver",
                column: "IdTeam",
                principalTable: "team",
                principalColumn: "id");
        }
    }
}
