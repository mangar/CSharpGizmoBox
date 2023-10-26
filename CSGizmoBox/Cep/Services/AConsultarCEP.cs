
using CSGizmoBox.Cep.Entity;
using Newtonsoft.Json;

namespace CSGizmoBox.Cep.Services
{
    public abstract class AConsultarCEP
    {
        protected HttpClient _httpClient;

        public AConsultarCEP(HttpClient httpClient) 
        { 
            this._httpClient = httpClient;        
        }


        public abstract Task<CepResponse> GetCEP(string cep);



        protected async Task<CepResponse> _APICall(string apiUrl)
        {
            CepResponse cepResponse = new CepResponse();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                cepResponse.HttpStatusCode = ((int)response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Dictionary<string, string> providerContent = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                    cepResponse.ProviderResponse = providerContent;

                }
                else
                {
                    cepResponse = CepResponseBuilder.CreateBadResponse(cepResponse, $"Error Message - Status Code: {response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                cepResponse = CepResponseBuilder.CreateBadResponse(cepResponse, $"Exception :: {ex.Message}");
            }


            return cepResponse;
        }



        public string NormilizarCep(string cep)
        {
            string _cep = cep.Replace("-", "").Replace(" ", "");
            if (cep.Count() < 8 )
            {
                _cep = _cep.PadRight(8, '0');
            }
            return _cep;
        }

        public string AddSeparadorCep(string cep)
        {
            string _cep = NormilizarCep(cep);
            _cep = $"{_cep.Substring(0, 5)}-{_cep.Substring(5, 3)}";
            return _cep;
        }



    }
}
