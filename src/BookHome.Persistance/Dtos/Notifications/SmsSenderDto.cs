namespace BookHome.Persistance.Dtos.Notifications;

public class SmsSenderDto
{
    public string Recipent { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
