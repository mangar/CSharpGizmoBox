using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class DoubleFieldsValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = DoubleFieldsValidation.Validate("SenhaDoCl13Nt3", "SenhaDoCl13Nt3");
            Assert.True(validationVO.IsValid);

            validationVO = DoubleFieldsValidation.Validate("nome@email.com", "nome@email.com");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = DoubleFieldsValidation.Validate("SenhaDoCl13Nt3", "senhaDoCl13Nt3");
            Assert.False(validationVO.IsValid);

            validationVO = DoubleFieldsValidation.Validate("nome@email.com", "Nome@Email.com");
            Assert.False(validationVO.IsValid);

            validationVO = DoubleFieldsValidation.Validate("nome@email. com br", "nome@email.com.br");
            Assert.False(validationVO.IsValid);

            validationVO = DoubleFieldsValidation.Validate("", "");
            Assert.False(validationVO.IsValid);
        }

    }
}