using System.Text.RegularExpressions;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class PlacaValidation
    {

        private static readonly string Pattern = @"^[A-Z]{3}((\d{1}[A-J]{1}\d{2})|(\d{4}))$";


        public static ValidationVO Validate(string content, string Codigo = "ERROR-PLACA", string Message = "Placa inválido")
        {

            string _content = (content == null ? "" : content).Replace(" ", "").Replace("-", "");


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
