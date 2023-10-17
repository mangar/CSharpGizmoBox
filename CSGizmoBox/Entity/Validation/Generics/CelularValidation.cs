using System.Text.RegularExpressions;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class CelularValidation
    {

        public static ValidationVO Validate(string content, string Codigo = "ERRO-CELULAR", string Message = "Celular Inválido")
        {

            string _content = (content == null ? "" : content).Replace(" ", "").Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("+", "");
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


        private static bool _Validar(string content)
        {
            // Remover caracteres não numéricos
            var _content = new string(content.ToCharArray(), 0, content.Length);

            // Verificar se o número tem um formato válido
            string pattern = @"^\d{2}\d{9}$"; // Formato com DDD (dois dígitos) + número de celular (nove dígitos)
            if (Regex.IsMatch(_content, pattern))
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
