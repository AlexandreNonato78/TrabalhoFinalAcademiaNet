using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoFinalAcademiaNet.Models;
public class Entrega
{
    public int Id { get; set; }
    public string Status { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Venda Venda { get; set; }
    public int IdVenda { get; set; }

}
