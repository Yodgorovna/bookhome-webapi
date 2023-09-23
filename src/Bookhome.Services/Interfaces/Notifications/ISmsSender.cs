using BookHome.Persistance.Dtos.Notifications;

namespace Bookhome.Services.Interfaces.Notifications;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsSenderDto message);
}
