
using CSGizmoBox.Cep.Entity;

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



        protected async Task<Dictionary<string, string>> _APICall(string apiUrl)
        {

            return null;
        }


    }
}
