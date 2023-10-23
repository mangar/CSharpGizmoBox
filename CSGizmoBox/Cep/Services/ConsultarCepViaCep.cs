using CSGizmoBox.Cep.Entity;
using Newtonsoft.Json;
using System.Net.Http;

namespace CSGizmoBox.Cep.Services
{
    public class ConsultarCepViaCep : AConsultarCEP
    {

        public static readonly string VIACEP_URL = "https://viacep.com.br/ws/|cep|/json/";

        public ConsultarCepViaCep(HttpClient httpClient) : base(httpClient) { }


        /**
         * 
         * {
         *   "cep": "04515-030",
         *   "logradouro": "Avenida Jacutinga",
         *   "complemento": "",
         *   "bairro": "Indianópolis",
         *   "localidade": "São Paulo",
         *   "uf": "SP",
         *   "ibge": "3550308",
         *   "gia": "1004",
         *   "ddd": "11",
         *   "siafi": "7107"
         * }
         * 
         */
        public override async Task<CepResponse> GetCEP(string cep)
        {
            CepResponse _response = new CepResponse();
            string _apiUrl = VIACEP_URL.Replace("|cep|", cep);

            try
            {               
                HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);
                _response.HttpStatusCode = ((int)response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    /*
                     1 - tratar o conteudo de retorno aqui (colocar no objeto CepValue e depois dentro do CepResponse
                     2 - Generalizar esse metodo. Dexar apenas a especificidade do tratamento do respose da API
                     */
                    Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

                    CepValue cepValue = new CepValue()
                    {
                        Value = dict["cep"],
                        Logradouro = dict["logradouro"],
                        Complemento = dict["complemento"],
                        Bairro = dict["bairro"],
                        Cidade = dict["localidade"],
                        Estado = dict["uf"],
                        DDD = dict["ddd"],
                    };

                    _response.CepValue = cepValue;
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
