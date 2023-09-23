using BookHome.Persistance.Dtos.Discounts;
using BookHome.Persistance.Validators.Dtos.Discounts;

namespace BookHome.UnitTest.ValidatorsTest.Discount
{
    public class DiscountCreateValidatorTest
    {
        [Theory]
        [InlineData("AA")]
        [InlineData("001")]
        [InlineData("05")]
        [InlineData("50")]
        [InlineData("Ad5d")]
        [InlineData("QE45dsfaAd45")]
        [InlineData("A")]
        [InlineData("A514-A")]
        [InlineData("/_fcdAA")]
        [InlineData("AA_=")]
        [InlineData("Books, we sell a books to our clients")]
        public void ShouldReturnInValidValidation(string name)
        {
            DiscountCreateDto discountCreateDto = new DiscountCreateDto()
            {
                Name = name,
            };
            var validator = new DiscountCreateValidator();
            var result = validator.Validate(discountCreateDto);
            Assert.False(result.IsValid);
        }
    }
}
