namespace CSGizmoBox.Entity.Validation.Generics
{
    public class IsDecimalValidation
    {
        public static ValidationVO Validate(string Content, string Codigo = "ERROR-DECIMAL", string Message = "Valor não é Decimal")
        {
            if (!decimal.TryParse(Content, out decimal result))
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
