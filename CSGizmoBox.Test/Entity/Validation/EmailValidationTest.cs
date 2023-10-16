using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class EmailValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = EmailValidation.Validate("nome@email.com");
            Assert.True(validationVO.IsValid);

            validationVO = EmailValidation.Validate("    nome@email.com");
            Assert.True(validationVO.IsValid);

            validationVO = EmailValidation.Validate("nome@email.com     ");
            Assert.True(validationVO.IsValid);

            validationVO = EmailValidation.Validate("     nome@email.com     ");
            Assert.True(validationVO.IsValid);

            validationVO = EmailValidation.Validate("     n o m e @ e m a i l .com     ");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = EmailValidation.Validate("nome");
            Assert.False(validationVO.IsValid, validationVO.toDebug());

            validationVO = EmailValidation.Validate("nome@email");
            Assert.False(validationVO.IsValid);
        }

    }
}