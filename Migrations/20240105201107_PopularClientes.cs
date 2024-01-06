using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoFinalAcademiaNet.Migrations
{
    /// <inheritdoc />
    public partial class PopularClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Clientes(NomeCliente, Cnpj, Endereco, Email, Telefone) " +
                "VALUES('BrPosto', '09876544', 'Av. Zaki Narchi, 1826, Vila Guilherme, São Paulo, SP, 02029-001, Brasil', 'br@email.com', '40049999')");
            migrationBuilder.Sql("INSERT INTO Clientes(NomeCliente, Cnpj, Endereco, Email, Telefone) " +
                "VALUES('Exxon', '22234555', 'Av. Brasil, 6261, Bonsucesso, Rio de Janeiro, RJ, 21040-360, Brasil','exxon@email.com', '55554000')");
            migrationBuilder.Sql("INSERT INTO Clientes(NomeCliente, Cnpj, Endereco, Email, Telefone) " +
                "VALUES('7Eleven', '44889900', 'Av. Dr. Afonso Vergueiro, 2373, Vila Augusta, Sorocaba, SP, 18040-000, Brasil', '7eleven@email.com', '88889999')");
            migrationBuilder.Sql("INSERT INTO Clientes(NomeCliente, Cnpj, Endereco, Email, Telefone) " +
                "VALUES('PostoBrasPetro', '01928374', 'R. Barão do Rio Branco, 197, Centro, Rondonópolis, MT, 78700-180, Brasil', 'petro@email.com', '0800557700')");
            migrationBuilder.Sql("INSERT INTO Clientes(NomeCliente, Cnpj, Endereco, Email, Telefone) " +
                "VALUES('PostoDoBairro', '77660552', 'R. José Bonifácio, 964, Madalena, Recife, PE, 50710-001, Brasil', 'bairro@email.com', '0800336688')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Clientes");
        }
    }
}
