using Newtonsoft.Json.Linq;

namespace TrabalhoFinalAcademiaNet.Services
{
    public class GetCoordService
    {
        private readonly HttpClient _httpClient;
        public GetCoordService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<(double Latitude, double Longitude)> GetFromCEP(string cep)
        {
            string apiKey = "AIzaSyAxtkTWQ0Zc8uaK4txTftwvHjv7px2NhgU";
            string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={cep}&key={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                JObject result = JObject.Parse(jsonResult);

                // Verificando se a resposta foi bem-sucedida e se há resultados
                if (result["status"].ToString() == "OK" && result["results"].HasValues)
                {
                    var location = result["results"][0]["geometry"]["location"];
                    double latitude = (double)location["lat"];
                    double longitude = (double)location["lng"];

                    return (latitude, longitude);
                }
            }

            // Caso algo dê errado ou não haja resultados
            throw new InvalidOperationException("Não foi possível obter as coordenadas para o CEP fornecido.");
        }
    }

}

