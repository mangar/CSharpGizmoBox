namespace CSGizmoBox.Cep.Services
{
    public class ConsultarCepFactory
    {
        public static AConsultarCEP CreateConsultarCep(HttpClient httpClient, string providerKey)
        {

            if (providerKey.ToUpper().Equals("VIACEP"))
            {
                return new ConsultarCepViaCep(httpClient);
            }

            else if (providerKey.ToUpper().Equals("OPENCEP"))
            {
                return new ConsultarCepOpenCep(httpClient);
            }
            else
            {
                throw new Exception("Provider Key Invalido");
            }
        }
    }
}
