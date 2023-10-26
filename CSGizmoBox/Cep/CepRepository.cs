using CSGizmoBox.Cep.Entity;
using CSGizmoBox.Cep.Services;
using CSGizmoBox.LocalCache;
using System.Text.Json;

namespace CSGizmoBox.Cep
{
    public class CepRepository
    {

        public static readonly int TEMPO_CACHE_SEGUNDOS = 5 * 60;

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

            CepResponse cepResponse = await _GetCepFromCache(cep);
            if (cepResponse != null)
            {
                return cepResponse;
            }
            else
            {
                cepResponse = new CepResponse()
                {
                    RequestAt = DateTime.Now,
                    HttpStatusCode = 400,
                    ConfigOptions = CepConfigOptions
                };


                foreach (string providerKey in CepConfigOptions.Providers)
                {

                    CepResponse _cepResponse = await ConsultarCepFactory.CreateConsultarCep(_httpClient, providerKey).GetCEP(cep);

                    cepResponse.Provider = providerKey;
                    cepResponse.CepValue = _cepResponse.CepValue;
                    cepResponse.HttpStatusCode = _cepResponse.HttpStatusCode;
                    cepResponse.HttpResponseMessage = _cepResponse.HttpResponseMessage;
                    cepResponse.ProviderResponse = _cepResponse.ProviderResponse;

                    if (cepResponse.HttpStatusCode == 200)
                    {
                        if (CepConfigOptions.FlagCache)
                        {
                            LCache.Set(cep, JsonSerializer.Serialize(cepResponse), CepRepository.TEMPO_CACHE_SEGUNDOS);
                        }
                        break;
                    }

                }


                cepResponse.ResponseAt = DateTime.Now;
                return cepResponse;
            }
        }



        protected async Task<CepResponse> _GetCepFromCache(string cep)
        {
            var cacheContent = (string)LCache.Get(cep);
            if (cacheContent != null)
            {
                CepResponse cepResponseCache = JsonSerializer.Deserialize<CepResponse>(cacheContent);
                cepResponseCache.Provider = $"{cepResponseCache.Provider}.CACHE";
                return cepResponseCache;
            }
            else
            {
                return null;
            }

        }


    }
}
