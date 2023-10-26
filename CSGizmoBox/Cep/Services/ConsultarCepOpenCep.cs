using CSGizmoBox.Cep.Entity;

namespace CSGizmoBox.Cep.Services
{
    public class ConsultarCepOpenCep : AConsultarCEP
    {

        public static readonly string URL = "https://opencep.com/v1/|cep|";

        public ConsultarCepOpenCep(HttpClient httpClient) : base(httpClient) { }


        /**
         * 
         * {
         *   "cep": "14055-490",
         *   "logradouro": "Rua Paraná",
         *   "complemento": "até 1498/1499",
         *   "bairro": "Ipiranga",
         *   "localidade": "Ribeirão Preto",
         *   "uf": "SP",
         *   "ibge": "3543402"
         * }
         * 
         */
        public override async Task<CepResponse> GetCEP(string cep)
        {           
            string _apiUrl = URL.Replace("|cep|", NormilizarCep(cep));

            CepResponse cepResponse = await _APICall(_apiUrl);

            if (cepResponse.IsHttpStatusCodeOK()) {

                CepValue cepValue = new CepValue()
                {
                    Value = cepResponse.ProviderResponse["cep"],
                    Logradouro = cepResponse.ProviderResponse["logradouro"],
                    Complemento = cepResponse.ProviderResponse["complemento"],
                    Bairro = cepResponse.ProviderResponse["bairro"],
                    Cidade = cepResponse.ProviderResponse["localidade"],
                    Estado = cepResponse.ProviderResponse["uf"]
                };
                cepResponse.CepValue = cepValue;

            }

            return cepResponse; 
        }

    }
}
