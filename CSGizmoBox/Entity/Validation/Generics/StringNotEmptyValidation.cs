namespace CSGizmoBox.Entity.Validation.Generics
{
    public class StringNotEmptyValidation
    {
        public static ValidationVO Validate(string Content, string Codigo = "ERROR-STRING-NOTEMPTY", string Message = "Campo deve ser preenchido")
        {
            if (string.IsNullOrWhiteSpace(Content))
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
