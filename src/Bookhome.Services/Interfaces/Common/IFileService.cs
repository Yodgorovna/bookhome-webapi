using Microsoft.AspNetCore.Http;

namespace Bookhome.Services.Interfaces.Common;

public interface IFileService 
{
    public Task<string> UploadImageAsync(IFormFile image, string rootpath);

    public Task<bool> DeleteImageAsync(string subpath);
    
    public Task<string> UploadAvatarAsync(IFormFile avatar);

    public Task<bool> DeleteAvatarAsync(string subpath);

}
