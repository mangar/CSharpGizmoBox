using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class CalularValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = CelularValidation.Validate("11 98761 1122");
            Assert.True(validationVO.IsValid);

            validationVO = CelularValidation.Validate("(11)91234-5678");
            Assert.True(validationVO.IsValid);

            validationVO = CelularValidation.Validate("(11).91234.56-78");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = CelularValidation.Validate("+55 11 98761 1234");
            Assert.False(validationVO.IsValid);

            validationVO = CelularValidation.Validate("11 3268 1234");
            Assert.False(validationVO.IsValid);

        }

    }
}