using System.Text.RegularExpressions;

namespace CSGizmoBox.Entity.Validation.Generics
{
    public class DoubleFieldsValidation
    {

        //private static readonly string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // @TODO
        public static ValidationVO Validate(string content1, string content2, string Codigo = "ERROR-EMAIL", string Message = "Email inválido")
        {

            //string _content = (content == null ? "" : content).Replace(" ", "");


            //if (string.IsNullOrWhiteSpace(_content) || !Regex.IsMatch(_content, EmailPattern, RegexOptions.IgnoreCase))
            //{
            //    return new ValidationVO()
            //    {
            //        IsValid = false,
            //        Codigo = Codigo,
            //        Message = Message
            //    };
            //}
            //else
            //{
            //    return ValidationVO.Empty();
            //}

            return null;
        }

    }
}
