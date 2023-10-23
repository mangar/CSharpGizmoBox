using CSGizmoBox.Cep.Entity;
using System.Net.Http;

namespace CSGizmoBox.Cep.Services
{
    public class ConsultarCepViaCep : AConsultarCEP
    {

        public static readonly string VIACEP_URL = "https://viacep.com.br/ws/|cep|/json/";

        public ConsultarCepViaCep(HttpClient httpClient) : base(httpClient)
        {
        }

        public override async Task<CepResponse> GetCEP(string cep)
        {
            CepResponse _response = new CepResponse();
            string _apiUrl = VIACEP_URL.Replace("|cep|", cep);

            try
            {               
                HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();




                    _response.ProviderResponse = content;

                }
                else
                {
                    _response = CepResponseBuilder.CreateBadResponse($"Error Message - Status Code: {response.StatusCode}");
                }

            } 
            catch (Exception ex)
            {
                _response = CepResponseBuilder.CreateBadResponse($"Error Message: {ex.Message}");
            }
            return _response;            
            
        }



    }
}
