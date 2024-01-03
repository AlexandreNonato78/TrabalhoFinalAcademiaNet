using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoFinalAcademiaNet.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome do produto deve ser informado!")]
        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; }
        
        [Required(ErrorMessage = "O nome do tipo do produto deve ser informado!")]
        [Display(Name = "Tipo do Produto")]
        public string Tipo { get; set; }

        //[Display(Name = "Imagem Normal")]
        //[StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        //public string ImagemUrl { get; set; }

        //[Display(Name = "Imagem Miniatura")]
        //[StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        //public string ImagemThumbnailUrl { get; set; }

        [Required(ErrorMessage = "A quantidade do produto deve ser informada!")]
        [Display(Name = "Quantidade-Estoque")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "O preço do produto deve ser informado!")]
        [Display(Name = "Preço do Produto")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999.99!")]
        public double Preco { get; set;}


        //public ICollection<Venda> Vendas { get; set; }

    }
}
