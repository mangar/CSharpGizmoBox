using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class IsIntegerValidation
    {
        public static ValidationVO Validate(string Content, string Codigo = "ERROR-INTEGER", string Message = "Valor não é Inteiro")
        {
            if (!int.TryParse(Content, out int result))
            {
                return new ValidationVO()
                {
                    IsValid = false,
                    Codigo = Codigo,
                    Message = $"{Message} {Content}"
                };
            }
            else
            {
                ValidationVO emptyValidation = ValidationVO.Empty();
                emptyValidation.Debug.Append($"{Content} >> {result}");
                return emptyValidation;
            }
        }

    }
}
