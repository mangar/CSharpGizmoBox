namespace CSGizmoBox.Cep.Entity
{
    public class CepResponse
    {
        public CepValue CepValue { get; set; }
        public string Provider { get; set; }
        public int HttpStatusCode { get; set; }
        public string HttpResponseMessage { get; set; }
        public string ProviderResponse { get; set; }
        public DateTime RequestAt { get; set; }
        public DateTime ResponseAt { get; set; }
        public CepConfigOptions ConfigOptions { get; set; }

    }


    public class CepResponseBuilder
    {

        public static CepResponse CreateBadResponse(string httpResponseMessage)
        {
            return new CepResponse
            {
                HttpStatusCode = 400,
                HttpResponseMessage = httpResponseMessage
            };
        }

    }



}
