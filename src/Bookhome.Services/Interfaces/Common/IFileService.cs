using Microsoft.AspNetCore.Http;

namespace Bookhome.Services.Interfaces.Common;

public interface IFileService 
{
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<string> DeleteImageAsync(string subpath);
    
    public Task<string> UploadAvatarAsync(IFormFile avatar);

    public Task<string> DeleteAvatarAsync(string subpath);

}
