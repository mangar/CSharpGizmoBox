using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class RangeValidationTest
    {
        [Fact]
        public void OK()
        {
            List<int> numeros = Enumerable.Range(0, 11).ToList();

            ValidationVO validationVO = RangeValidation.Validate(4, numeros);
            Assert.True(validationVO.IsValid);

            validationVO = RangeValidation.Validate(0, numeros);
            Assert.True(validationVO.IsValid);

            validationVO = RangeValidation.Validate(10, numeros);
            Assert.True(validationVO.IsValid);
        }


        [Fact]
        public void Not_OK()
        {
            List<int> numeros = Enumerable.Range(0, 11).ToList();

            ValidationVO validationVO = RangeValidation.Validate(100, numeros);
            Assert.False(validationVO.IsValid);

            validationVO = RangeValidation.Validate(-1, numeros);
            Assert.False(validationVO.IsValid);

            validationVO = RangeValidation.Validate(11, numeros);
            Assert.False(validationVO.IsValid);

        }



    }
}