using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Example.Entity.Validation
{
    public class ValidationExamples
    {

        static void Main(string[] args)
        {
            var validateExamples = new ValidationExamples();
            //validateExamples.SingleValidateExample();


            validateExamples.MultipleValidateExample();

        }


        public void SingleValidateExample()
        {
            Console.WriteLine("---- Single Validate");

            User user = new User()
            {
                Id = 1,
                Nome = "Test",  
                Email = "",
                Senha = "",
            };

            var validationEmail = EmailValidation.Validate(user.Email);
            Console.WriteLine($@"Email ... 
                    IsValid?: {validationEmail.IsValid} / 
                    Codigo: {validationEmail.Codigo} / 
                    Message: {validationEmail.Message}");
        }


        public void MultipleValidateExample()
        {
            Console.WriteLine("---- Multiple Validate");

            User user = new User()
            {
                Id = 1,
                Nome = " ",
                Email = "",
                Senha = "",
            };


            UserValidate userValidate = new UserValidate(user);
            Console.WriteLine($"IsValid: {userValidate.Validate()}");


            foreach (var message in userValidate.ValidateMessages)
            {
                Console.WriteLine($"- {message.Codigo} .. {message.Message}");
            }


        }


    }
}
