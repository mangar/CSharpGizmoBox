using CSGizmoBox.Entity.Validation.Generics;
using CSGizmoBox.Entity.Validation;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class StringNotEmptyValidationTest
    {
        [Fact]
        public void OK()
        {
            Assert.True(StringNotEmptyValidation.Validate("string not empty").IsValid);

            Assert.True(StringNotEmptyValidation.Validate(" . ").IsValid);
            
        }


        [Fact]
        public void Not_OK()
        {
            Assert.False(StringNotEmptyValidation.Validate("  ").IsValid);

            Assert.False(StringNotEmptyValidation.Validate("").IsValid);

            Assert.False(StringNotEmptyValidation.Validate(null).IsValid);

        }

    }
}