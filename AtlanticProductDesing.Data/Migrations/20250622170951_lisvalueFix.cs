using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlanticProductDesign.Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class lisvalueFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductConfigurationId",
                table: "ListValues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ListValues_ProductConfigurationId",
                table: "ListValues",
                column: "ProductConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListValues_ProductConfiguration_ProductConfigurationId",
                table: "ListValues",
                column: "ProductConfigurationId",
                principalTable: "ProductConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListValues_ProductConfiguration_ProductConfigurationId",
                table: "ListValues");

            migrationBuilder.DropIndex(
                name: "IX_ListValues_ProductConfigurationId",
                table: "ListValues");

            migrationBuilder.DropColumn(
                name: "ProductConfigurationId",
                table: "ListValues");
        }
    }
}
