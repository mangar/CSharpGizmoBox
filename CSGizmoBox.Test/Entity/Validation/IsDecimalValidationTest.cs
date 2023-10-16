using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class IsIntegerValidationTest
    {

        [Fact]
        public void OK()
        {
            ValidationVO validationVO = IsIntegerValidation.Validate("10");
            Assert.True(validationVO.IsValid);

            validationVO = IsIntegerValidation.Validate("0");
            Assert.True(validationVO.IsValid);

            validationVO = IsIntegerValidation.Validate("    0     ");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = IsIntegerValidation.Validate("");
            Assert.False(validationVO.IsValid, "1 - " + validationVO.toDebug());

            validationVO = IsIntegerValidation.Validate("  ");
            Assert.False(validationVO.IsValid, "2 - " + validationVO.toDebug());

            validationVO = IsIntegerValidation.Validate("10,10");
            Assert.False(validationVO.IsValid, $":: {validationVO.toDebug()}");

            validationVO = IsIntegerValidation.Validate("10.10");
            Assert.False(validationVO.IsValid, $":: {validationVO.toDebug()}");

            validationVO = IsIntegerValidation.Validate("Não é um Integer Valido");
            Assert.False(validationVO.IsValid, $":: {validationVO.toDebug()}");
        }




    }
}