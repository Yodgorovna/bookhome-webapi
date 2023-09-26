using BookHome.Persistance.Dtos.Auth;
using BookHome.Persistance.Validators.Dtos.Auth;

namespace BookHome.UnitTest.ValidatorsTest.AuthTest
{
    public class UserLoginValidatorTest
    {
        [Theory]
        [InlineData("+998951092161", "AasA_S@#%123")]
        [InlineData("+998971234567", "Abcd_123!@#")]
        [InlineData("+998998877665", "P@$$w_0rd123")]
        [InlineData("+998933532323", "Qwer_ty!@123")]
        [InlineData("+998901234567", "Hello123@aa")]
        [InlineData("+998935757566", "MyP@ssw0r_d")]
        [InlineData("+998912565645", "GreenSal2e!@")]
        [InlineData("+998979695433", "Testing_@123")]
        [InlineData("+998934267324", "Welcome_123@")]
        [InlineData("+998931379532", "Security#1@")]

        public void CheckRightValid(string phone, string password)
        {
            var dto = new LoginDto()
            {
                PhoneNumber = phone,
                Password = password
            };

            LoginValidator userLoginDto = new LoginValidator();
            var result = userLoginDto.Validate(dto);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("-998951092161", "invalidpassword")]
        [InlineData("123456789", "asAS@#%123")]
        [InlineData("+99895109161", "")]
        [InlineData("invalidphone", "asAS@#%123")]
        [InlineData("+99895109216", "      ")]
        [InlineData("+9985109216", "123456789")]
        [InlineData("1092161", "UPPERCASE")]
        [InlineData("+", "noSpecialCharacters")]
        [InlineData("+99895jbdsdb1092161", "longpasswordlongpasswordlongpasswordlongpasswordlongpasswordlongpassword")]
        [InlineData("+99895145092161", "noDigits#")]

        public void checkWrongTest(string phone, string password)
        {
            var dto = new LoginDto()
            {
                PhoneNumber = phone,
                Password = password
            };

            var validator = new LoginValidator();
            var result = validator.Validate(dto);

            Assert.False(result.IsValid);
        }
    }
}
