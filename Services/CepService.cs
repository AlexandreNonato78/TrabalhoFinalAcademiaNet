namespace TrabalhoFinalAcademiaNet.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class CepService
    {
        private readonly HttpClient _httpClient;

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> BuscarEnderecoPorCep(string cep)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Endereco>(content);
                }
                else
                {
                    // Tratar erros de requisição aqui, se necessário
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções, como falha na conexão com o serviço
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    public class Endereco
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
        public string? Numero { get; set; }
    }


}
