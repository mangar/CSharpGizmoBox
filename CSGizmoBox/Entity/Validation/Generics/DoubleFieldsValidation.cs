namespace CSGizmoBox.Entity.Validation.Generics
{
    public class DoubleFieldsValidation
    {
        public static ValidationVO Validate(string content1, string content2, string Codigo = "ERROR-DOUBLE", string Message = "Valor para os campos devem ser iguais")
        {

            if (
                (string.IsNullOrWhiteSpace(content1) || string.IsNullOrWhiteSpace(content2)) ||
                (string.Compare(content1, content2) != 0)
               )


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
