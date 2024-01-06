using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoFinalAcademiaNet.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Gasolina', 'Combustível', '', '3.15')");
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Álcool', 'Combustível', '', '2.65')");
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Diesel', 'Combustível', '', '3.99')");
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Gás 6', 'Cilindro Gás', '', '15.99')");
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Gás 12', 'Cilindro Gás', '', '29.99')");
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Gás 55', 'Cilindro Gás', '', '99.99')");
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Óleo Moto', 'Lubrificante', '', '9.99')");
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Óleo Carro', 'Lubrificante', '', '19.99')");
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Tipo, QuantidadeEstoque, Preco) " +
                "VALUES('Óleo Caminhão', 'Lubrificante', '', '35.99')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
