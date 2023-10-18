using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class DomainValidationTest
    {
        [Fact]
        public void OK()
        {
            List<string> computadores = new List<string>() { "Apple", "IBM", "Compaq", "ACER" };


            ValidationVO validationVO = DomainValidation.Validate("Apple", computadores);
            Assert.True(validationVO.IsValid);

            validationVO = DomainValidation.Validate("IBM", computadores);
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void Not_OK()
        {
            List<string> computadores = new List<string>() { "Apple", "IBM", "Compaq", "ACER" };

            ValidationVO validationVO = DomainValidation.Validate("apple", computadores);
            Assert.False(validationVO.IsValid);

            validationVO = DomainValidation.Validate("Kabum", computadores);
            Assert.False(validationVO.IsValid);

            validationVO = DomainValidation.Validate("", computadores);
            Assert.False(validationVO.IsValid);

            validationVO = DomainValidation.Validate(null, computadores);
            Assert.False(validationVO.IsValid);

        }

    }
}