﻿using System.Globalization;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class HoraValidation
    {

        public static ValidationVO Validate(string content, string Codigo = "ERRO-HORA", string Message = "Hora Inválida")
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

        private static bool _Validar(string horaContent, string formatoHora = "HH:mm")
        {
            CultureInfo cultura = CultureInfo.InvariantCulture;
            if (DateTime.TryParseExact(horaContent, formatoHora, cultura, DateTimeStyles.None, out DateTime resultado))
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

