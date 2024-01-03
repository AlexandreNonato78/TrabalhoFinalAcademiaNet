using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoFinalAcademiaNet.Models
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a data da venda!")]
        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; }
        
        [Required(ErrorMessage = "Informe a quantidade para Entrega!")]
        [Display(Name = "Quantidade-Entrega")]
        public int Quantidade { get; set; }

        [Display(Name = "Total(R$)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Range(0, double.MaxValue, ErrorMessage = "O TotalVenda não pode ser negativo.")]      
        public double TotalVenda { get; set; }

        [StringLength(100, ErrorMessage = "o tamanho máximo é de 200 caracteres")]
        [Required(ErrorMessage = "Informe o endereço para Entrega!")]
        [Display(Name = "Endereço da Entrega")]
        public string Endereco { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }

        //public string CarrinhoCompraId { get; set; }
    }
}
