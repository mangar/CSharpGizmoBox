using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class DataValidationTest
    {
        [Fact]
        public void OK()
        {
            ValidationVO validationVO = DataValidation.Validate("01/01/2001");
            Assert.True(validationVO.IsValid);

            validationVO = DataValidation.Validate("31/12/2015");
            Assert.True(validationVO.IsValid);

            validationVO = DataValidation.Validate("12/12/2012");
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            ValidationVO validationVO = DataValidation.Validate("40/12/2015");
            Assert.False(validationVO.IsValid);

            validationVO = DataValidation.Validate("01/15/2015");
            Assert.False(validationVO.IsValid);

            validationVO = DataValidation.Validate("6 190 161.90..001/6-x");
            Assert.False(validationVO.IsValid);
        }

    }
}