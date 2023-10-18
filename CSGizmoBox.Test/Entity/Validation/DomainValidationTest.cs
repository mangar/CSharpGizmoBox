using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;

namespace CSGizmoBox.Test.Entity.Validation
{
    public class DomainValidationTest
    {
        [Fact]
        public void OK_string()
        {
            List<string> computadores = new List<string>() { "Apple", "IBM", "Compaq", "ACER" };

            ValidationVO validationVO = DomainValidation<string>.Validate("Apple", computadores);
            Assert.True(validationVO.IsValid);

            validationVO = DomainValidation<string>.Validate("IBM", computadores);
            Assert.True(validationVO.IsValid);
        }

        [Fact]
        public void OK_int()
        {
            List<int> anos = new List<int>() { 1980, 1990, 2000, 2010, 2020 };

            ValidationVO validationVO = DomainValidation<int>.Validate(2000, anos);
            Assert.True(validationVO.IsValid);

            validationVO = DomainValidation<int>.Validate(1980, anos);
            Assert.True(validationVO.IsValid);

        }









        [Fact]
        public void Not_OK_string()
        {
            List<string> computadores = new List<string>() { "Apple", "IBM", "Compaq", "ACER" };

            ValidationVO validationVO = DomainValidation<string>.Validate("apple", computadores);
            Assert.False(validationVO.IsValid);

            validationVO = DomainValidation<string>.Validate("Kabum", computadores);
            Assert.False(validationVO.IsValid);

            validationVO = DomainValidation<string>.Validate("", computadores);
            Assert.False(validationVO.IsValid);

            validationVO = DomainValidation<string>.Validate(null, computadores);
            Assert.False(validationVO.IsValid);

        }


        [Fact]
        public void Not_OK_int()
        {
            List<int> anos = new List<int>() { 1980, 1990, 2000, 2010, 2020 };

            ValidationVO validationVO = DomainValidation<int>.Validate(2001, anos);
            Assert.False(validationVO.IsValid);

            validationVO = DomainValidation<int>.Validate(0, anos);
            Assert.False(validationVO.IsValid);

        }



    }
}