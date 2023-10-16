using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class CNPJValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = CNPJValidation.Validate("09.939.450/0001-19");
            Assert.True(validationVO.IsValid);

            validationVO = CNPJValidation.Validate("61901619000161");
            Assert.True(validationVO.IsValid);

            validationVO = CNPJValidation.Validate("6 190 161.90..001/6-1");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = CNPJValidation.Validate("09.939.450/0011-19");
            Assert.False(validationVO.IsValid);

            validationVO = CNPJValidation.Validate("61901619000121");
            Assert.False(validationVO.IsValid);

            validationVO = CNPJValidation.Validate("6 190 161.90..001/6-x");
            Assert.False(validationVO.IsValid);
        }

    }
}