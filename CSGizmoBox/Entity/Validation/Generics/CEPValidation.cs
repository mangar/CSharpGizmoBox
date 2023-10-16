using System.Text.RegularExpressions;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class CEPValidation
    {
        private static readonly string Pattern = @"^(?:(\d{5}-\d{3})|(\d{5}))$";

        // @TODO
        public static ValidationVO Validate(string content, string Codigo = "ERRO-CEP", string Message = "CEP inválido")
        {

            string _content = (content == null ? "" : content).Replace(" ", "");

            if (string.IsNullOrWhiteSpace(_content) || !Regex.IsMatch(_content, Pattern, RegexOptions.IgnoreCase))
            {
                return new ValidationVO()
                {
                    IsValid = false,
                    Codigo = Codigo,
                    Message = Message
                };
            }
            else
            {
                return ValidationVO.Empty();
            }

        }

    }
}
