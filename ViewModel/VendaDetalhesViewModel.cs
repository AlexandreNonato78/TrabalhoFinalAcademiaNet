namespace TrabalhoFinalAcademiaNet.ViewModel
{
    public class VendaDetalhesViewModel
    {
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public double TotalVenda { get; set; }

        public string ClienteNome { get; set; }
        public string ClienteEmail { get; set; }

        public string NomeItem { get; set; }
        public double PrecoItem { get; set; }

        public int EntregaId { get; set; }
        public string StatusEntrega { get; set; }
        public string Endereco {  get; set; }
        public double LatitudeEntrega { get; set; }
        public double LongitudeEntrega { get; set; }        
    }

}
