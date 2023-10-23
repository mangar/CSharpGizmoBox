using CSGizmoBox.Cep.Entity;
using CSGizmoBox.Cep.Services;

namespace CSGizmoBox.Cep
{
    class CepRepository
    {
        public CepConfigOptions CepConfigOptions { get; set; } = new CepConfigOptions();

        protected HttpClient _httpClient = new HttpClient();


        private CepRepository(CepConfigOptions cepConfigOptions)
        {
            CepConfigOptions = cepConfigOptions;
        }

        private static CepRepository _instance;

        public static CepRepository Instance(CepConfigOptions? config)
        {
            if (CepRepository._instance == null)
            {
                CepRepository._instance = new CepRepository(config);
            }
            return CepRepository._instance;
        }



        public async Task<CepResponse> GetCep(string cep) 
        {
            CepResponse cepResponse = new CepResponse()
            {
                RequestAt = DateTime.Now,
                HttpStatusCode = 400
            };


            foreach (string providerKey in CepConfigOptions.Providers)
            {
                
                CepResponse _cepResponse = await ConsultarCepFactory.CreateContularCep(providerKey).GetCEP(cep);
                if (_cepResponse.HttpStatusCode == 200)
                {
                    cepResponse.Provider = providerKey;
                    cepResponse.CepValue = _cepResponse.CepValue;
                    cepResponse.HttpStatusCode = _cepResponse.HttpStatusCode;
                    cepResponse.ProviderResponse = _cepResponse.ProviderResponse;
                    
                    break;
                }

            }


            cepResponse.ResponseAt = DateTime.Now;
            return cepResponse;
        }




    }
}
