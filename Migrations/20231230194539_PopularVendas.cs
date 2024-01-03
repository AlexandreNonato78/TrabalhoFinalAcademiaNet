using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoFinalAcademiaNet.Migrations
{
    /// <inheritdoc />
    public partial class PopularVendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Vendas(DataVenda, Quantidade, TotalVenda, Endereco, ClienteId,  ProdutoId) " +
                        "VALUES('2023-08-20', 50, '', 'Av. Dr. Afonso Vergueiro, 2373, Vila Augusta, Sorocaba, SP, 18040-000, Brasil', 3, 2)");
            migrationBuilder.Sql("INSERT INTO Vendas(DataVenda, Quantidade, TotalVenda, Endereco, ClienteId,  ProdutoId) " +
                        "VALUES('2023-08-20', 20, '', 'Av. Dr. Afonso Vergueiro, 2373, Vila Augusta, Sorocaba, SP, 18040-000, Brasil', 3, 3)");
            migrationBuilder.Sql("INSERT INTO Vendas(DataVenda, Quantidade, TotalVenda, Endereco, ClienteId,  ProdutoId) " +
                        "VALUES('2023-08-20', 35, '', 'Av. Dr. Afonso Vergueiro, 2373, Vila Augusta, Sorocaba, SP, 18040-000, Brasil', 3, 4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Vendas");
        }
    }
}