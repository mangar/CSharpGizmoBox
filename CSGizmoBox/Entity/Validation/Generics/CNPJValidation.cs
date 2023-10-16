using System.Text.RegularExpressions;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class CNPJValidation
    {

        public static ValidationVO Validate(string content, string Codigo = "ERRO-CNPJ", string Message = "CNPJ inválido")
        {

            string _content = (content == null ? "" : content).Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "");
            if (!_ValidarCNPJ(_content))
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



        private static bool _ValidarCNPJ(string cnpj)
        {
            // Remover caracteres não numéricos
            cnpj = new string(cnpj.ToCharArray(), 0, 14);

            if (cnpj.Length != 14)
                return false;

            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += (int)(cnpj[i] - '0') * multiplicadores1[i];
            }

            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            if ((int)(cnpj[12] - '0') != digitoVerificador1)
            {
                return false;
            }

            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += (int)(cnpj[i] - '0') * multiplicadores2[i];
            }

            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            return (int)(cnpj[13] - '0') == digitoVerificador2;
        }


    }
}
