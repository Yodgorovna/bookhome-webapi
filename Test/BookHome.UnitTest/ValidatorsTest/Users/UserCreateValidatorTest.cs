using BookHome.Persistance.Dtos.Users;
using BookHome.Persistance.Validators.Dtos.Users;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace BookHome.UnitTest.ValidatorsTest.Users
{
    public class UserCreateValidatorTest
    {
        //[Theory]
        //[InlineData("", "Goziyeva", "aa0561687", "+998335103545545", "@@#@$%$^")]
        //[InlineData("L", "Goziyeva32", " KA0561687", "+998335107545", "1111111")]
        //[InlineData("@", "123124234", "KA05616", "+998338103545", "AAAAAAAAA")]
        //[InlineData("13234242", "#", "KA0561687978", "+998335103544", "     ")]
        //[InlineData("", "", " 0561687", "-998335108545", "AA")]
        //[InlineData(" ", " ", "", "+9978335106545", "AAAA11")]
        //[InlineData("Malikajuniorasfsf", "asfsdhgthtrhwrthrhrhrhrhwr", "000987896237", "+998335103543", "hhaa@@11")]
        //[InlineData("Malikajuniorasfsf", "Asfsdhgthtrhwrthrhrhrhrhwr", "000987896237", "+99845335103547", "AAaa@@ii")]
        //[InlineData("AIERTURWHLGRJTHBDRJGHKDTRHJR", "SHDFGEHGRHJMEGFWMRHGRGRTHETHTYHTE", "000987896237", "+998905103545", "AAaaaa11")]
        //public void ShouldReturnInValidValidationResult(string firstname, string lastname, string passportSeriaNumber, string phone, string password)
        //{
        //    byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        //    IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        //    var userCreateDto = new UserCreateDto()
        //    {
        //        FirstName = firstname,
        //        LastName = lastname,
        //        PassportSeriaNumber = passportSeriaNumber,
        //        BirthDate = DateTime.Now,
        //        PhoneNumber = phone,
        //        Password = password,
        //        ImagePath = imageFile
        //    };

        //    var user = new UserCreateValidator();
        //    var result = user.Validate(userCreateDto);
        //    Assert.False(result.IsValid);
        //}

        //[Theory]
        //[InlineData("Lobar", "Goziyeva", "KA0561687", "+998933644016", "AA@@11aa#")]
        //[InlineData("Gulnur", "Boranbaeva", "CK0561687", "+998903644016", "AA@@11aa#")]
        //[InlineData("Malika", "Bobonazarova", "AD0561687", "+998883644016", "AA@@11aa#")]
        //[InlineData("Laylo", "Yangibayeva", "AD0561687", "+998713644016", "AA@@11aa#")]

        //public void ShouldReturnValidValidationResult(string firstname, string lastname, string passportSeriaNumber, string phone, string password)
        //{
        //    var userCreateDto = new UserCreateDto()
        //    {
        //        FirstName = firstname,
        //        LastName = lastname,
        //        PassportSeriaNumber = passportSeriaNumber,
        //        BirthDate = DateTime.Now,
        //        PhoneNumber = phone,
        //        Password = password,
        //    };

        //    var user = new UserCreateValidator();
        //    var result = user.Validate(userCreateDto);
        //    Assert.True(result.IsValid);
        //}

        //[Theory]
        //[InlineData(6)]
        //[InlineData(7)]
        //[InlineData(8)]
        //[InlineData(9)]
        //[InlineData(9.5)]
        //[InlineData(5.1)]
        //public void ShouldReturnWrongImageFileSize(double imageSizeMB)
        //{
        //    byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        //    long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
        //    IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        //    UserCreateDto user = new UserCreateDto()
        //    {
        //        FirstName = "Lobar",
        //        LastName = "Goziyeva",
        //        PassportSeriaNumber = "KA0561687",
        //        BirthDate = DateTime.Now,
        //        PhoneNumber = "+998933644016",
        //        Password = "AA11@@aa",
        //    };
        //    var validator = new UserCreateValidator();
        //    var result = validator.Validate(user);
        //    Assert.False(result.IsValid);
        //}

        //[Theory]
        //[InlineData(2.95)]
        //[InlineData(3)]
        //[InlineData(2.5)]
        //[InlineData(1)]
        //[InlineData(0.5)]
        //[InlineData(0.75)]
        //public void ShouldReturnValidImageFileSize(double imageSizeMB)
        //{
        //    byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        //    long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
        //    IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        //    UserCreateDto user = new UserCreateDto()
        //    {
        //        FirstName = "Lobar",
        //        LastName = "Goziyeva",
        //        PassportSeriaNumber = "KA0561687",
        //        BirthDate = DateTime.Now,
        //        PhoneNumber = "+998933644016",
        //        Password = "AA11@@aa#",
        //    };
        //    var validator = new UserCreateValidator();
        //    var result = validator.Validate(user);
        //    Assert.True(result.IsValid);
        //}

        //[Theory]
        //[InlineData("file.png")]
        //[InlineData("file.jpg")]
        //[InlineData("file.jpeg")]
        //[InlineData("file.bmp")]
        //[InlineData("file.svg")]
        //public void ShouldReturnCorrectImageFileExtension(string imagename)
        //{
        //    byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        //    IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        //    UserCreateDto user = new UserCreateDto()
        //    {
        //        FirstName = "Lobar",
        //        LastName = "Goziyeva",
        //        PassportSeriaNumber = "KA0561687",
        //        BirthDate = DateTime.Now,
        //        PhoneNumber = "+998933644016",
        //        Password = "AA11@@aa#",
        //        ImagePath = imageFile
        //    };
        //    var validator = new UserCreateValidator();
        //    var result = validator.Validate(user);
        //    Assert.True(result.IsValid);
        //}

        //[Theory]
        //[InlineData("file.zip")]
        //[InlineData("file.mp3")]
        //[InlineData("file.html")]
        //[InlineData("file.gif")]
        //[InlineData("file.txt")]
        //[InlineData("file.HEIC")]
        //[InlineData("file.mp4")]
        //[InlineData("file.avi")]
        //[InlineData("file.mvk")]
        //[InlineData("file.vaw")]
        //[InlineData("file.webp")]
        //[InlineData("file.pdf")]
        //[InlineData("file.doc")]
        //[InlineData("file.docx")]
        //[InlineData("file.xls")]
        //[InlineData("file.exe")]
        //[InlineData("file.dll")]
        //public void ShouldReturnWrongImageFileExtension(string imagename)
        //{
        //    byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        //    IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        //    UserCreateDto user = new UserCreateDto()
        //    {
        //        FirstName = "Lobar",
        //        LastName = "Goziyeva",
        //        PassportSeriaNumber = "KA0561687",
        //        BirthDate = DateTime.Now,
        //        PhoneNumber = "+998933644016",
        //        Password = "AA11@@aa#",
        //        ImagePath = imageFile
        //    };
        //    var validator = new UserCreateValidator();
        //    var result = validator.Validate(user);
        //    Assert.False(result.IsValid);
        //}

    }
}
