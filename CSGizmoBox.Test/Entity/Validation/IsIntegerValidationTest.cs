using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class IsDecimalValidationTest
    {

        [Fact]
        public void OK()
        {
            ValidationVO validationVO = IsDecimalValidation.Validate("10.10");
            Assert.True(validationVO.IsValid);

            validationVO = IsDecimalValidation.Validate("10,10");
            Assert.True(validationVO.IsValid, $":: {validationVO.toDebug()}");

            validationVO = IsDecimalValidation.Validate("10");
            Assert.True(validationVO.IsValid);

            validationVO = IsDecimalValidation.Validate("0");
            Assert.True(validationVO.IsValid);

            validationVO = IsDecimalValidation.Validate("    0     ");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = IsDecimalValidation.Validate("");
            Assert.False(validationVO.IsValid, "1 - " + validationVO.toDebug());

            validationVO = IsDecimalValidation.Validate("  ");
            Assert.False(validationVO.IsValid, "2 - " + validationVO.toDebug());
        }

    }
}