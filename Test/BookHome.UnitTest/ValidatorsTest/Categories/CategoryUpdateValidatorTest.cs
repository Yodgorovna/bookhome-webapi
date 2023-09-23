using BookHome.Persistance.Dtos.Categories;
using BookHome.Persistance.Validators.Dtos.Categories;

namespace BookHome.UnitTest.ValidatorsTest.Categories
{
    public class CategoryUpdateValidatorTest
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
            CategoryUpdateValidator validator = new CategoryUpdateValidator();

            CategoryUpdateDto categoryUpdateDto = new CategoryUpdateDto()
            {
                Name = value,
            };

            var result = validator.Validate(categoryUpdateDto);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("No")]
        [InlineData("                        ")]
        [InlineData("Ilmiiiykzjbxfnv,zkjxfbnvz,kjxdbvnzlkjxdfbvn")]
        [InlineData("  ")]

        public void CheckFalseTest(string value)
        {
            CategoryUpdateValidator validator = new CategoryUpdateValidator();

            CategoryUpdateDto categoryUpdateDto = new CategoryUpdateDto()
            {
                Name = value,
            };

            var result = validator.Validate(categoryUpdateDto);
            Assert.False(result.IsValid);
        }
    }
}
