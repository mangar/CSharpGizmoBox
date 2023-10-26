namespace CSGizmoBox.Cep.Entity
{
    public class CepResponse
    {
        public CepValue CepValue { get; set; }
        public string Provider { get; set; }
        public int HttpStatusCode { get; set; }
        public string HttpResponseMessage { get; set; }
        public Dictionary<string, string> ProviderResponse { get; set; }
        public DateTime RequestAt { get; set; }
        public DateTime ResponseAt { get; set; }
        public CepConfigOptions ConfigOptions { get; set; }


        public bool IsHttpStatusCodeOK()
        {
            if (HttpStatusCode != null && HttpStatusCode == 200)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }


    }


    public class CepResponseBuilder
    {

        public static CepResponse CreateBadResponse(CepResponse cepResponse, string httpResponseMessage)
        { 
            cepResponse.HttpStatusCode = 400;
            cepResponse.HttpResponseMessage = httpResponseMessage;
            return cepResponse;
        }

    }



}
