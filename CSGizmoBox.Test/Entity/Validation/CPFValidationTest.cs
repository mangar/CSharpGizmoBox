using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class CPFValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = CPFValidation.Validate("753.847.315-75");
            Assert.True(validationVO.IsValid);

            validationVO = CPFValidation.Validate("63164825749");
            Assert.True(validationVO.IsValid);

        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = CEPValidation.Validate("753.847.315-74");
            Assert.False(validationVO.IsValid, validationVO.toDebug());

            validationVO = CEPValidation.Validate(" ");
            Assert.False(validationVO.IsValid);

            validationVO = CEPValidation.Validate("11111111111");
            Assert.False(validationVO.IsValid);
        }

    }
}