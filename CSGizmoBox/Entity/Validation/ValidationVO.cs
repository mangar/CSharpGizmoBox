using System.Text;

namespace CSGizmoBox.Entity.Validation
{
    public class ValidationVO
    {
        public bool IsValid { get; set; } = false;
        public string Codigo { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public List<string> Debug { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"[{Codigo}] {Message}";
        }

        public string toDebug(string separator = "\n")
        {

            StringBuilder sb = new StringBuilder();
            foreach (var item in Debug)
            {
                sb.Append(item.ToString()).Append(separator);
            }
            return sb.ToString();
        }


        public static ValidationVO Empty()
        {
            return new ValidationVO()
            {
                IsValid = true,
                Codigo = string.Empty,
                Message = string.Empty
            };
        }


    }
}
