namespace TrabalhoFinalAcademiaNet.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Endereco
    {

        [Key] public int Id { get; set; }
        [Column("Cep")] // Mapeia a propriedade Cep para a coluna "Cep" no banco de dados
        public string Cep { get; set; }

        [Column("Logradouro")] // Mapeia a propriedade Logradouro para a coluna "Logradouro" no banco de dados
        public string? Logradouro { get; set; }

        [Column("Bairro")] // Mapeia a propriedade Bairro para a coluna "Bairro" no banco de dados
        public string? Bairro { get; set; }

        [Column("Localidade")] // Mapeia a propriedade Localidade para a coluna "Localidade" no banco de dados
        public string? Localidade { get; set; }

        [Column("Uf")] // Mapeia a propriedade Uf para a coluna "Uf" no banco de dados
        public string? Uf { get; set; }

        [Column("Complemento")] // Mapeia a propriedade Complemento para a coluna "Complemento" no banco de dados
        public string? Complemento { get; set; }
        public string? Numero { get; set; }
        // Chave estrangeira para Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }

}
