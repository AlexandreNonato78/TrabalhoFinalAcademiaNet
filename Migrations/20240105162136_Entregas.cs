using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoFinalAcademiaNet.Migrations
{
    /// <inheritdoc />
    public partial class Entregas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Entregas");

            migrationBuilder.AddColumn<int>(
                name: "VendaId",
                table: "Entregas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_VendaId",
                table: "Entregas",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Vendas_VendaId",
                table: "Entregas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_Vendas_VendaId",
                table: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Entregas_VendaId",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "Entregas");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Entregas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
