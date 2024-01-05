using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoFinalAcademiaNet.Models;
public class Entrega
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("VendaId")]
    public Venda Venda { get; set; }
    public int VendaId { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
}
