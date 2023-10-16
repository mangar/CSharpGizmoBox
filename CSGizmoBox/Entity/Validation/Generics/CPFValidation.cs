using System.Text.RegularExpressions;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class CPFValidation
    {
        public static ValidationVO Validate(string content, string Codigo = "ERRO-CPF", string Message = "CPF inválido")
        {
            string _content = (content == null ? "" : content).Replace(" ", "").Replace(".", "").Replace("-", "");
            if (!_ValidarCPF(_content))
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


        private static bool _ValidarCPF(string cpf)
        {
            // Remover caracteres não numéricos
            cpf = new string(cpf.ToCharArray(), 0, 11);

            if (cpf.Length != 11)
                return false;

            if (cpf == "00000000000" ||
                cpf == "11111111111" ||
                cpf == "22222222222" ||
                cpf == "33333333333" ||
                cpf == "44444444444" ||
                cpf == "55555555555" ||
                cpf == "66666666666" ||
                cpf == "77777777777" ||
                cpf == "88888888888" ||
                cpf == "99999999999")
            {
                return false;
            }

            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (int)(cpf[i] - '0') * (10 - i);
            }

            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            if ((int)(cpf[9] - '0') != digitoVerificador1)
            {
                return false;
            }

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (int)(cpf[i] - '0') * (11 - i);
            }

            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            return (int)(cpf[10] - '0') == digitoVerificador2;
        }



    }
}
