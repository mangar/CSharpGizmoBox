using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class CEPValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = CEPValidation.Validate("04515-030");
            Assert.True(validationVO.IsValid);

            validationVO = CEPValidation.Validate("00000-100");
            Assert.True(validationVO.IsValid);
            
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = CEPValidation.Validate("04515030");
            Assert.False(validationVO.IsValid, validationVO.toDebug());

            validationVO = CEPValidation.Validate("14055xxx");
            Assert.False(validationVO.IsValid);

            validationVO = CEPValidation.Validate("cepce-cep");
            Assert.False(validationVO.IsValid);
        }

    }
}