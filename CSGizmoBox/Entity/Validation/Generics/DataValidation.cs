using System.Globalization;
using System.Text.RegularExpressions;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class DataValidation
    {

        public static ValidationVO Validate(string content, string Codigo = "ERRO-DATA", string Message = "DATA Inválida")
        {

            string _content = (content == null ? "" : content).Replace(" ", "").Replace(".", "").Replace("-", "");
            if (!_Validar(_content))
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



        private static bool _Validar(string dataContent, string formatoData = "dd/MM/yyyy")
        {
            CultureInfo cultura = CultureInfo.InvariantCulture;
            if (DateTime.TryParseExact(dataContent, formatoData, cultura, DateTimeStyles.None, out DateTime resultado))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
