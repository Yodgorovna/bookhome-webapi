using BookHome.Persistance.Dtos.Auth;
using BookHome.Persistance.Validators.Dtos.Auth;

namespace BookHome.UnitTest.ValidatorsTest.AuthTest
{
    public class UserRegisterValidatorTest
    {
        [Theory]
        [InlineData("Aliyeva", "Ali", "+998901234567", "StrongP@ss123")]
        [InlineData("Samit", "tooShort", "+998901234567", "StrongP@ss123")]
        [InlineData("Sobir", "Doe", "+998952341232", "StrongP@ss123")]
        [InlineData("Akbar", "Doe", "+998901234567", "StrongP@ss123")]
        [InlineData("Soli", "Doe", "+998901234567", "StrongP@ss123")]
        [InlineData("MirShakar", "Doe", "+998901234567", "StrongP@ss123")]
        [InlineData("Ali", "Doe", "+998901234567", "32HGyt^&^")]
        [InlineData("Sobir", "Doe", "+998901234567", "noSym^&*BK12bols")]
        [InlineData("Javlonhn", "Doe", "+998904563412", "StrongP@ss123")]
        [InlineData("Aohn", "Doe", "+998901234567", "dfkbhjGJV78875^&*^&*")]

        public void ValidUserRegisterDto_ReturnsNoValidationErrors(
        string firstName, string lastName, string phoneNumber, string password)
        {
            var dto = new RegisterDto
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Password = password
            };

            RegisterValidator validationRules = new RegisterValidator();
            var result = validationRules.Validate(dto);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("", "Doe", "+998901234567", "weak")]
        [InlineData("John", "", "+998901234567", "short")]
        [InlineData("Alice", "Johnson", "+998910101010", "noSymbols")]
        [InlineData("Jane", "Smith", "+998912345678", "noUppercase")]
        [InlineData("Bob", "Johnson", "+998910101010", "noDigit")]
        [InlineData("Chris", "Brown", "", " noLowercase")]
        [InlineData("d", "Taylor", "+998912345678", "short")]
        [InlineData("Elas,kejbala", "Adams", "+998901234567", "noSpecialCharacter")]
        [InlineData("Frank", "White", "+998912345678", "longpasswordlongpasswordlongpasswordlongpasswordlongpasswordlongpassword")]
        [InlineData("Grdkhjsvflskdjbasleidfjbkalewsk,dace", "Moore", "+998910101010", "onlyDigits12345")]

        public void InvalidUserRegisterDto_ReturnsValidationErrors(
            string firstName, string lastName, string phoneNumber, string password)
        {
            // Arrange
            var dto = new RegisterDto
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Password = password
            };

            RegisterValidator validationRules = new RegisterValidator();
            var result = validationRules.Validate(dto);

            Assert.False(result.IsValid);
        }
    }
}
