namespace CSGizmoBox.Helpers
{
    public class strings
    {
        /**
         * Se a string eh null or empty retorna o 'defaults' 
         * 
         */
        public static string GetDefault(string value, string defaults = "")
        {
            if (string.IsNullOrEmpty(value)) 
            {
                return defaults;
            }
            else
            {
                return value;
            }
        }

    }
}
