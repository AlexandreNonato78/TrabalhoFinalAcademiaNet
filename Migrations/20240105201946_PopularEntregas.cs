using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoFinalAcademiaNet.Migrations
{
    /// <inheritdoc />
    public partial class PopularEntregas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Entregas(NomeCliente, EnderecoEntrega, Latitude, Longitude) " +
                    "VALUES('BrPosto','Av. Zaki Narchi, 1826, Vila Guilherme, São Paulo, SP, 02029-001, Brasil', -23.5096143, -46.6178953)");
            migrationBuilder.Sql("INSERT INTO Entregas(NomeCliente, EnderecoEntrega, Latitude, Longitude) " +
                     "VALUES('AutoPosto Sorocaba', 'Av. Dr. Afonso Vergueiro, 2373, Vila Augusta, Sorocaba, SP, 18040-000, Brasil', -23.4997196, -47.4742394)");
            migrationBuilder.Sql("INSERT INTO Entregas(NomeCliente, EnderecoEntrega, Latitude, Longitude) " +
                     "VALUES('Posto Passo Fundo', 'Avenida Perimetral Deputado Guaracy Marinho, Lucas Araújo, Passo Fundo, Rio Grande do Sul, 99074800', -28.2684723, -52.4423871)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Entregas");
        }
    }
}
