namespace CSGizmoBox.Cep.Entity
{
    public class CepConfigOptions
    {

        public static readonly string PROVIDER_VIACEP = "VIACEP";
        public static readonly string PROVIDER_OPENCEP = "OPENCEP";

        public bool FlagCache { get; set; } = true;

        public List<string> Providers { get; set; } = new List<string> 
        { 
            CepConfigOptions.PROVIDER_VIACEP,
            CepConfigOptions.PROVIDER_OPENCEP,
        };
      
    }
}
