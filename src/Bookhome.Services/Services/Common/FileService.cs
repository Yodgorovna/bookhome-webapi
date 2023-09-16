using Bookhome.Services.Helpers;
using Bookhome.Services.Interfaces.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Bookhome.Services.Services.Common;

public class FileService : IFileService
{

    private readonly string MEDIA = "media";
    private readonly string IMAGES = "images";
    private readonly string AVATAR = "avatar";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }
    public Task<string> DeleteAvatarAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteImageAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        string NewImageName = MediaHelper.MakeImageName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGES, NewImageName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }
}
