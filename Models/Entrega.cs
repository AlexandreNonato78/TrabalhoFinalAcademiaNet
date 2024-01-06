using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoFinalAcademiaNet.Models;
public class Entrega
{
    [Key]
    public int Id { get; set; }

    public string NomeCliente { get; set; }

    public string EnderecoEntrega { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
}
