using System.ComponentModel.Design;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class RangeValidation
    {
        public static ValidationVO Validate(int content, List<int> range, string Codigo = "ERROR-RANGE", string Message = "Valor do campo fora da faixa.")
        {

            if (content == null || range.Count == 0 || !range.Contains(content))
            {
                return new ValidationVO()
                {
                    IsValid = false,
                    Codigo = Codigo,
                    Message = Message
                };
            }
            else { 
                return ValidationVO.Empty();
            } 

        }

    }
}
