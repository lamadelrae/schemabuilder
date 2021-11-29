using SchemaBuilder.SharedKernel;
using Xunit;

namespace SchemaBuilder.UnitTests.SharedKernelTests
{
    public class ValidatorTests
    {
        [Fact]
        public void ShouldReturnTrue()
        {
            bool isValid = new Validator<string>(x => !string.IsNullOrEmpty(x)).Validate("Some String");

            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnFalse()
        {
            bool isValid = new Validator<string>(x => !string.IsNullOrEmpty(x)).Validate(string.Empty);

            Assert.False(isValid);
        }
    }
}
