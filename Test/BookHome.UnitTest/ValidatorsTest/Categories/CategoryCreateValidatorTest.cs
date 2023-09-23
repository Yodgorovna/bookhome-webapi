using BookHome.Persistance.Dtos.Categories;
using BookHome.Persistance.Validators.Dtos.Categories;

namespace BookHome.UnitTest.ValidatorsTest.Categories
{
    public class CategoryCreateValidatorTest
    {
        [Theory]
        [InlineData("Badiiy kitoblar")]
        [InlineData("Tarixiy kitoblar")]
        [InlineData("Ilmiy kitoblar")]
        [InlineData("Jahon adabiyoti")]
        [InlineData("O'zbek adabiyoti")]
        [InlineData("Rus adabiyoti")]
        [InlineData("Diniy kitoblar")]

        public void CheckRightTest(string value)
        {
            CategoryCreateValidator validator = new CategoryCreateValidator();

            CategoryCreateDto categoryCreateDto = new CategoryCreateDto()
            {
                Name = value,
            };

            var result = validator.Validate(categoryCreateDto);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("No")]
        [InlineData("                           ")]
        [InlineData("Badiifzddvc jzxdfdfvkjzbxfv,kzjbxfnv,zkjxfbnvz,kjxdbvnzlkjxdfbvn")]
        [InlineData("  ")]

        public void CheckFalseTest(string value)
        {
            CategoryCreateValidator validator = new CategoryCreateValidator();

            CategoryCreateDto categoryCreateDto = new CategoryCreateDto()
            {
                Name = value,
            };

            var result = validator.Validate(categoryCreateDto);
            Assert.False(result.IsValid);
        }
    }
}
