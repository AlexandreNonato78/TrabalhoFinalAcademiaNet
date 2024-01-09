using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoFinalAcademiaNet.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "o tamanho máximo é de 50 caracteres")]
        [Required(ErrorMessage = "Informe o nome do Cliente!")]
        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        [StringLength(20, ErrorMessage = "o tamanho máximo é de 20 caracteres")]
        [Required(ErrorMessage = "Informe o CNPJ do Cliente!")]
        [Display(Name = "CNPJ do Cliente")]
        public string Cnpj { get; set; }

        //[StringLength(100, ErrorMessage = "o tamanho máximo é de 200 caracteres")]
        //[Required(ErrorMessage = "Informe o endereço do Cliente!")]
        //[Display(Name = "Endereço do Cliente")]
        //public string Endereco { get; set; }

        [StringLength(20, ErrorMessage = "o tamanho máximo é de 20 caracteres")]
        [Required(ErrorMessage = "Informe o Email do Cliente!")]
        [Display(Name = "Email do Cliente")]
        public string Email { get; set; }

        [StringLength(30, ErrorMessage = "o tamanho máximo é de 30 caracteres")]
        [Required(ErrorMessage = "Informe o Telefone do Cliente!")]
        [Display(Name = "Telefone do Cliente")]
        public string Telefone { get; set; }

        //[Display(Name = "Imagem Normal")]
        //[StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        //public string ImagemUrl { get; set; }

        //[Display(Name = "Imagem Miniatura")]
        //[StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        //public string ImagemThumbnailUrl { get; set; }

        //[Display(Name = "Cliente comprou?")]
        //public bool IsClientesVendas { get; set; }


        //public ICollection<Venda> Vendas { get; set; }
        public Endereco Endereco { get; set; }

    }
}
