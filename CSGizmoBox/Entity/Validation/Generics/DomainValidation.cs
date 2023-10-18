namespace CSGizmoBox.Entity.Validation.Generics
{
    public class DomainValidation<T>
    {
        public static ValidationVO Validate(T content, List<T> domain, string Codigo = "ERROR-DOMAIN", string Message = "Valor não faz parte do domínio para o campo.")
        {

            if (content == null || domain == null || domain.Count == 0)
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
