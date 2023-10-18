namespace CSGizmoBox.Entity.Validation.Generics
{
    public class DomainValidation
    {
        public static ValidationVO Validate(string content, List<string> domain, string Codigo = "ERROR-DOMAIN", string Message = "Valor não faz parte do domínio para o campo.")
        {

            if (string.IsNullOrWhiteSpace(content) || domain == null || domain.Count == 0)
            {
                return new ValidationVO()
                {
                    IsValid = false,
                    Codigo = Codigo,
                    Message = Message
                };
            }


            if (!domain.Contains(content))
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
