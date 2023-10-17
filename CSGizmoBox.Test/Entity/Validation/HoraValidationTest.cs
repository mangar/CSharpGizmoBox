using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class HoraValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = HoraValidation.Validate("23:40");
            Assert.True(validationVO.IsValid);

            validationVO = HoraValidation.Validate("00:59");
            Assert.True(validationVO.IsValid);

            validationVO = HoraValidation.Validate("01:15");
            Assert.True(validationVO.IsValid);

            validationVO = HoraValidation.Validate("13:13");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = HoraValidation.Validate("24:99");
            Assert.False(validationVO.IsValid);

            validationVO = HoraValidation.Validate("01/15");
            Assert.False(validationVO.IsValid);

            validationVO = HoraValidation.Validate("30:15");
            Assert.False(validationVO.IsValid);

            validationVO = HoraValidation.Validate("6 19:0 1-x");
            Assert.False(validationVO.IsValid);
        }

    }
}