using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class PlacaValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = PlacaValidation.Validate("ABC-1A23");
            Assert.True(validationVO.IsValid);

            validationVO = PlacaValidation.Validate("ABC-1023");
            Assert.True(validationVO.IsValid);

            validationVO = PlacaValidation.Validate("ABC1023");
            Assert.True(validationVO.IsValid);

            validationVO = PlacaValidation.Validate("ABC 1023");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = EmailValidation.Validate("123-1234");
            Assert.False(validationVO.IsValid);

            validationVO = EmailValidation.Validate("ABC-1X34");
            Assert.False(validationVO.IsValid);

            validationVO = EmailValidation.Validate("A0C-1X34");
            Assert.False(validationVO.IsValid);

            validationVO = EmailValidation.Validate("ABC|1234");
            Assert.False(validationVO.IsValid);
        }

    }
}