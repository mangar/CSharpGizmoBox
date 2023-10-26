using CSGizmoBox.Cep.Entity;
using CSGizmoBox.LocalCache;
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
            string _apiUrl = VIACEP_URL.Replace("|cep|", NormilizarCep(cep));

            CepResponse cepResponse = await _APICall(_apiUrl);

            if (cepResponse.IsHttpStatusCodeOK()) {

                CepValue cepValue = new CepValue()
                {
                    Value = cepResponse.ProviderResponse["cep"],
                    Logradouro = cepResponse.ProviderResponse["logradouro"],
                    Complemento = cepResponse.ProviderResponse["complemento"],
                    Bairro = cepResponse.ProviderResponse["bairro"],
                    Cidade = cepResponse.ProviderResponse["localidade"],
                    Estado = cepResponse.ProviderResponse["uf"],
                    DDD = cepResponse.ProviderResponse["ddd"]
                };
                cepResponse.CepValue = cepValue;

            }

            return cepResponse;            
        }



    }
}
