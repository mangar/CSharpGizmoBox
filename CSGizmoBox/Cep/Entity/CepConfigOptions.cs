namespace CSGizmoBox.Cep.Entity
{
    public class CepConfigOptions
    {

        public static readonly string VIACEP = "VIACEP";

        public bool FlagCache { get; set; } = true;

        public List<string> Providers { get; set; } = new List<string> 
        { 
            CepConfigOptions.VIACEP 
        };







        /*
        CepConfigOptions
        - cache or not
        - ordem da lista de pesquisa de ceps
        - 
        */

    }
}
